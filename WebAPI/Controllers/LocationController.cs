using Application.LogicInterfaces;
using Domain.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationLogic locationLogic;

    public LocationController(ILocationLogic locationLogic)
    {
        this.locationLogic = locationLogic;
    }
    
    [HttpPost, Route("create")]
    public async Task<ActionResult<Location>> CreateAsync(Location location)
    {
        try
        {
            locationLogic.saveLocation(location);
            return Created($"/Location/{location.Id}", location);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("GetByIdAsync")]
    public async Task<ActionResult<Location>> GetByUserIdAsync([FromQuery] int id)
    {
        try
        {
            Location result = locationLogic.findById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("GetAll")]
    public async Task<ActionResult<IEnumerable<Location>>> GetAll()
    {
        try
        {
            IEnumerable<Location> result = await locationLogic.findAll();
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}