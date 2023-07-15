using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Post;
using GrpcClasses.User;
using SearchParameters = Domain.Models.SearchParameters;

namespace GrpcAcces.Grpc;

public class PostGrpcService : IPostDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private PostGrpc.PostGrpcClient postGrpcClient = new PostGrpc.PostGrpcClient(channel);

    public async Task<Post> CreateAsync(Post post)
    {
        Console.WriteLine("grpc called");
        PostModelGrpc postModel = new PostModelGrpc()
        {
            Id = post.Id,
            UserId = post.userID,
            Category = post.category,
            Title = post.Title,
            Description = post.description,
            ImageUrl = post.imageUrl,
            Location = post.location
        };
        postGrpcClient.createPost(postModel);
        return post;
    }

    public async Task<IEnumerable<Post>> FindByParameters(SearchParameters parameters)
    {
        if (parameters.title == null)
        {
            parameters.title = "niull";
        }
        if (parameters.category== null)
        {
            parameters.category = "niull";
        }
        if (parameters.location == null)
        {
            parameters.location = "niull";
        }

        if (parameters.userId == null)
        {
            parameters.userId = 0;
        }
        var req = new GrpcClasses.Post.SearchParameters() { Title = parameters.title,Category = parameters.category, Location = parameters.location, UserId = parameters.userId};
        using var call = postGrpcClient.findByParameters(req);
        List<Post> list = new List<Post>();
        while ( await call.ResponseStream.MoveNext())
        {
            PostModelGrpc model = call.ResponseStream.Current;
            Post matchModel = new Post(model.Id,model.UserId, model.Title, model.Description,model.ImageUrl, model.Category, model.Location);
            list.Add(matchModel);
        }

        return list;
    }

    public async Task<Post?> GetByIdAsync(int Id)
    {
        var req = new GrpcClasses.Post.GetById() { Id = Id };
        var post = postGrpcClient.findById(req);
        Post newPost = new Post(post.Id,post.UserId,post.Title,post.Description,post.ImageUrl, post.Category, post.Location);
        return newPost;
    }

    public async Task<IEnumerable<Post>> GetByUserIdAsync(int UserId)
    {
        var req = new GrpcClasses.Post.GetById() { Id = UserId };
        using var call = postGrpcClient.findByUserId(req);
        List<Post> list = new List<Post>();
        while ( await call.ResponseStream.MoveNext())
        {
            PostModelGrpc model = call.ResponseStream.Current;
            Post matchModel = new Post(model.Id,model.UserId, model.Title, model.Description,model.ImageUrl, model.Category, model.Location);
            list.Add(matchModel);
        }

        return list;
    }

    public void UpdatePost(Post post)
    {
        PostModelGrpc postModel = new PostModelGrpc()
        {
            Id = post.Id,
            UserId = post.userID,
            Category = post.category,
            Title = post.Title,
            Description = post.description,
            ImageUrl = post.imageUrl,
            Location = post.location
        };
        postGrpcClient.updatePostAsync(postModel);
    }

    public void deletePost(int id)
    {
        var req = new GrpcClasses.Post.GetById() { Id = id };
        postGrpcClient.deletePostAsync(req);
    }
}