using Domain.Models;

namespace Application.LogicInterfaces;

public interface ILocationLogic
{
    void saveLocation(Location location);
    Task<List<Location>> findAll();
    Location findById(int id);
}