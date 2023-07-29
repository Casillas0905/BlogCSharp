using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICategoryService
{
    Task saveCategory(Category Category);
    Task<IEnumerable<Category>> findAll();
    Task<Category> findById(int id);
}