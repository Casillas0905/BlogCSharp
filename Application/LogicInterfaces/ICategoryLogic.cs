using Domain.Models;

namespace Application.LogicInterfaces;

public interface ICategoryLogic
{
    void saveCategory(Category Category);
    Task<List<Category>> findAll();
    Category findById(int id);
}