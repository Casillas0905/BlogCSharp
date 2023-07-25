using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{

    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    /*[HttpPost,Route("create")]
    public async Task<ActionResult<Post>> CreateAsync(Post dto)
    {
        try
        {
            Post created = await postLogic.CreateAsync(dto);
            return Created($"/Post/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("FindByParameters")]
    public async Task<ActionResult<User>> FindByParametersAsync([FromQuery] SearchParameters? parameters)
    {
        try
        {
            var todos = await postLogic.FindByParameters(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}"), Route("findById")]
    public async Task<ActionResult<Post>> FindById([FromRoute] int id)
    {
        try
        {
            Post? result = await postLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("FindAll")]
    public async Task<ActionResult<IEnumerable<Post>>> FindAll()
    {
        try
        {
            Task<IEnumerable<Post>> result = postLogic.FindByParameters(null);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("GetByUserIdAsync")]
    public async Task<ActionResult<IEnumerable<Post>>> GetByUserIdAsync([FromQuery] int Userid)
    {
        try
        {
            IEnumerable<Post> result = await postLogic.GetByUserIdAsync(Userid);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] Post dto)
    {
        try
        {
            await postLogic.UpdatePost(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{deleteid:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int deleteid)
    {
        try
        {
            await postLogic.deletePost(deleteid);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }*/
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> GetById([FromRoute] int id)
    {
        try
        {
            Post result = await postLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}