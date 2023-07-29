using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class LocationLogic : ILocationLogic
{
    private readonly ILocationDao locationDao;

    public LocationLogic(ILocationDao locationDao)
    {
        this.locationDao = locationDao;
    }

    public void saveLocation(Location location)
    {
        locationDao.saveLocation(location);
    }

    public Task<List<Location>> findAll()
    {
        return locationDao.findAll();
    }

    public Location findById(int id)
    {
        return locationDao.findById(id);
    }
}