using Application.DaoInterfaces;
using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Location;

namespace GrpcAcces.Grpc;

public class LocationGrpcService : ILocationDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private LocationGrpc.LocationGrpcClient locationGrpcClient = new LocationGrpc.LocationGrpcClient(channel);


    public void saveLocation(Location location)
    {
         Console.WriteLine("grpc called");
         LocationModelGrpc locationModel = new LocationModelGrpc()
         {
             Id = location.Id,
             Location = location.location 
         };
        locationGrpcClient.saveLocation(locationModel);
    }

    public async Task<List<Location>> findAll()
    {
        var req = new GrpcClasses.Location.Empty();
        using var call = locationGrpcClient.findAll(req);
        List<Location> list = new List<Location>();
        while ( await call.ResponseStream.MoveNext())
        {
            LocationModelGrpc model = call.ResponseStream.Current;
            Location locationModel = new Location(model.Id, model.Location);
            list.Add(locationModel);
        }

        return list;
    }

    public Location findById(int id)
    {
        var req = new GrpcClasses.Location.GetById() { Id = id };
        var locationModel = locationGrpcClient.findById(req);
        Location location = new Location(locationModel.Id, locationModel.Location);
        return location;
    }
}