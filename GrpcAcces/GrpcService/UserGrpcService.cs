using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Grpc.Net.Client;
using GrpcClasses.User;

namespace GrpcAcces.Grpc;

public class UserGrpcService : IUserDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private UserGrpc.UserGrpcClient userGrpcClient = new UserGrpc.UserGrpcClient(channel);

    public void CreateAsync(User user)
    {
        Console.WriteLine("grpc called");
        UserModelGrpc userModel = new UserModelGrpc()
        {
            Id = user.Id,
            Password = user.Password,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Year = user.year,
            Day = user.day,
            Month = user.month,
            Administrator = user.administrator
        };
        userGrpcClient.saveUser(userModel);
    }

    public User? GetByEmailAsync(string email)
    {
        var req = new GetByEmail() { Email = email };
        var user= userGrpcClient.findByEmail(req);
        User newUser = new User(user.Id, user.FirstName, user.Password, user.Email, user.LastName,user.Day, user.Month, user.Year,user.Administrator);
        return newUser;
    }

    public User? GetByIdAsync(int id)
    {
        var req = new GetById() { Id = id };
        var user= userGrpcClient.findById(req);
        User newUser = new User(user.Id, user.FirstName, user.Password, user.Email, user.LastName,user.Day, user.Month, user.Year,user.Administrator);
        return newUser;
    }

    public void UpdateUser(User user)
    {
        UserModelGrpc userGrpc = new UserModelGrpc()
        {
            Id = user.Id,
            Password = user.Password,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Year = user.year,
            Day = user.day,
            Month = user.month,
            Administrator = user.administrator
        };
        userGrpcClient.updateUserAsync(userGrpc);
        Console.WriteLine("update grpc called");
    }

    public void deleteUser(int id)
    {
        var req = new GetById() { Id = id };
        userGrpcClient.deleteUserAsync(req);
    }
}