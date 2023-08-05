using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SaveController : ControllerBase
{
    private readonly ISaveLogic saveLogic;

    public SaveController(ISaveLogic saveLogic)
    {
        this.saveLogic = saveLogic;
    }
    
    
    [HttpPost,Route("create")]
    public async Task<ActionResult<Save>> CreateAsync(Save dto)
    {
        try
        {
            saveLogic.saveSave(dto);
            return Created($"/Save/{dto.id}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{getById:int}")]
    public async Task<ActionResult<Save>> findByUserId([FromRoute] int getById)
    {
        try
        {
            List<Save> result = await saveLogic.findByUserId(getById);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete("delete/{deleteId:int}")]
    public async void DeleteUser([FromRoute] int deleteId){
        try
        {
            saveLogic.deleteSaveById(deleteId);
            Ok("user delete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            StatusCode(500, e.Message);
        }
    }
}