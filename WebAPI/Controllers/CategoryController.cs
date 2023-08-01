using Application.LogicInterfaces;
using Domain.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryLogic categoryLogic;

    public CategoryController(ICategoryLogic categoryLogic)
    {
        this.categoryLogic = categoryLogic;
    }
    
    [HttpPost, Route("create")]
    public async Task<ActionResult<Category>> CreateAsync(Category category)
    {
        try
        {
            categoryLogic.saveCategory(category);
            return Created($"/Message/{category.Id}", category);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{getById:int}")]
    public async Task<ActionResult<Category>> GetByIdAsync([FromRoute] int getById)
    {
        try
        {
            Category result = categoryLogic.findById(getById);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("GetAll")]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        try
        {
            IEnumerable<Category> result = await categoryLogic.findAll();
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}