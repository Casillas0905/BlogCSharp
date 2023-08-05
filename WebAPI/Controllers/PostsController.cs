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

    [HttpPost,Route("create")]
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
    
    [HttpGet,Route("FindByParameters")]
    public async Task<ActionResult<Post>> FindByParametersAsync([FromQuery] string? title,[FromQuery] string? location,[FromQuery] string? category,[FromQuery] int userId)
    {
        try
        {
            SearchParameters searchParameters = new SearchParameters(title,location,category,userId);
            var todos = await postLogic.FindByParameters(searchParameters);
            return Ok(todos);
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
    
    [HttpPatch,Route("patch")]
        public async Task<ActionResult<Post>> UpdateUser(Post dto){
            try
            {
               await postLogic.UpdatePost(dto);
               return Created($"/posts/{dto.Id}", dto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    [HttpDelete("{deleteId:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int deleteId)
    {
        try
        {
            await postLogic.deletePost(deleteId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{getById:int}")]
    public async Task<ActionResult<Post>> GetById([FromRoute] int getById)
    {
        try
        {
            Post? result = await postLogic.GetByIdAsync(getById);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}