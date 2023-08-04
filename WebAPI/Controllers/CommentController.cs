using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentLogic CommentLogic;

    public CommentController(ICommentLogic CommentLogic)
    {
        this.CommentLogic = CommentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync(Comment comment)
    {
        try
        {
            CommentLogic.CreateAsync(comment);
            return Created($"/Message/{comment.id}", comment);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet("{postId:int}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetByPostId([FromRoute] int postId)
    {
        try
        {
            IEnumerable<Comment> result = await CommentLogic.GetByPostIdAsync(postId);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}