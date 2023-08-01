using Application.DaoInterfaces;
using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Category;
using GrpcClasses.Post;

namespace GrpcAcces.Grpc;

public class CategoryGrpcService : ICategoryDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private CategoryGrpc.CategoryGrpcClient categoryGrpcClient = new CategoryGrpc.CategoryGrpcClient(channel);

    public void saveCategory(Category category)
    {
        Console.WriteLine("grpc called");
        CategoryModelGrpc categoryModel = new CategoryModelGrpc()
        {
            Id = category.Id,
            Category = category.category 
        };
        categoryGrpcClient.saveCategory(categoryModel);
    }

    public async Task<List<Category>> findAll()
    {
        var req = new GrpcClasses.Category.Empty();
        using var call = categoryGrpcClient.findAll(req);
        List<Category> list = new List<Category>();
        while ( await call.ResponseStream.MoveNext())
        {
            CategoryModelGrpc model = call.ResponseStream.Current;
            Category categoryModel = new Category(model.Id, model.Category);
            list.Add(categoryModel);
        }

        return list;
    }

    public Category findById(int id)
    {
        var req = new GrpcClasses.Category.GetById() { Id = id };
        Console.WriteLine("Id"+id);
        var categoryModel = categoryGrpcClient.findById(req);
        Category location = new Category(categoryModel.Id, categoryModel.Category);
        return location;
    }
}