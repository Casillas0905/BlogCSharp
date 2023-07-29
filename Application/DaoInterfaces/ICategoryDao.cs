using Domain.Models;

namespace Application.DaoInterfaces;

public interface ICategoryDao
{
    void saveCategory(Category Category);
    Task<List<Category>> findAll();
    Category findById(int id);
}