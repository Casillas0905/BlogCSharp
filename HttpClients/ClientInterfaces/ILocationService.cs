using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ILocationService
{
    Task saveLocation(Location location);
    Task<IEnumerable<Location>> findAll();
    Task<Location> findById(int id);
}