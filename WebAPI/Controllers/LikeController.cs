using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeLogic likeLogic;

    public LikeController(ILikeLogic likeLogic)
    {
        this.likeLogic = likeLogic;
    }
    
    
    [HttpPost,Route("create")]
    public async Task<ActionResult<Like>> CreateAsync(Like dto)
    {
        try
        {
            likeLogic.saveLike(dto);
            return Created($"/Save/{dto.id}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("findLikesByPostLiked/{findLikesByPostLiked:int}")]
    public async Task<ActionResult<int>> findLikesByPostLiked([FromRoute] int findLikesByPostLiked)
    {
        try
        {
            var result =likeLogic.findLikesByPostLiked(findLikesByPostLiked);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet,Route("findByPostLikedAndUserLiking")]
    public async Task<ActionResult<bool>> findByPostLikedAndUserLiking([FromQuery] int postId,[FromQuery] int userId)
    {
        try
        {
            var todos =likeLogic.findByPostLikedAndUserLiking(postId,userId);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete,Route("deleteLikeByByPostLikedAndUserLiking")]
    public async void DeleteUser([FromQuery] int postId,[FromQuery] int userId){
        try
        {
            likeLogic.deleteLikeByByPostLikedAndUserLiking(postId,userId);
            Ok("like delete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            StatusCode(500, e.Message);
        }
    }
}