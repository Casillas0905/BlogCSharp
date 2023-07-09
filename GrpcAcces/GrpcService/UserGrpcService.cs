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

    public User CreateAsync(User user)
    {
        Console.WriteLine("grpc called");
        DateGrpc date = new DateGrpc()
        {
            Year = user.Date.Year,
            Day = user.Date.Day,
            Month = user.Date.Month
        };
        UserModelGrpc userModel = new UserModelGrpc()
        {
            Id = user.Id,
            Password = user.Password,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Date = date,
            Administrator = user.administrator
        };
        userGrpcClient.saveUser(userModel);
        return user;
    }

    public User? GetByEmailAsync(string email)
    {
        var req = new GetByEmail() { Email = email };
        var user= userGrpcClient.findByEmail(req);
        DateOnly date = new DateOnly(user.Date.Year, user.Date.Month, user.Date.Day);
        User newUser = new User(user.Id, user.FirstName, user.Password, user.Email, user.LastName,date,user.Administrator);
        return newUser;
    }

    public User? GetByIdAsync(int id)
    {
        var req = new GetById() { Id = id };
        var user= userGrpcClient.findById(req);
        DateOnly date = new DateOnly(user.Date.Year, user.Date.Month, user.Date.Day);
        User newUser = new User(user.Id, user.FirstName, user.Password, user.Email, user.LastName,date,user.Administrator);
        return newUser;
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void deleteUser(int id)
    {
        throw new NotImplementedException();
    }
}