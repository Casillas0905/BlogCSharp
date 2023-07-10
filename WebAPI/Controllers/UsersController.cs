using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost,Route("create")]
    public async Task<ActionResult<User>> CreateAsync(User dto)
    {
        try
        {
            userLogic.CreateAsync(dto);
            return Created($"/users/{dto.Id}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, Route("GetByEmail")]
    public async Task<ActionResult<User>> GetByEmailAsync([FromQuery] string email)
    {
        try
        {
            User user = await userLogic.GetByEmailAsync(email);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, Route("GetById")]
    public async Task<ActionResult<IEnumerable<User>>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
            User user = await userLogic.GetByIdAsync(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    public async void DeleteUser([FromQuery] int id){
        try
        {
            userLogic.deleteUser(id);
            Ok("user delete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<User>> UpdateUser(User dto){
        try
        {
            User user = await userLogic.UpdateUser(dto);
            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}