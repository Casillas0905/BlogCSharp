using Domain.Models;

namespace Application.DaoInterfaces;

public interface ILocationDao
{
    void saveLocation(Location location);
    Task<List<Location>> findAll();
    Location findById(int id);
}