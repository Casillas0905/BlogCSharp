using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class CategoryLogic : ICategoryLogic
{
    private readonly ICategoryDao categoryDao;

    public CategoryLogic(ICategoryDao categoryDao)
    {
        this.categoryDao = categoryDao;
    }

    public void saveCategory(Category category)
    {
        categoryDao.saveCategory(category);
    }

    public Task<List<Category>> findAll()
    {
        return categoryDao.findAll();
    }

    public Category findById(int id)
    {
        return categoryDao.findById(id);
    }
}