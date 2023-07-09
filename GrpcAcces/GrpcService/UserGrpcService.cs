using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Grpc.Net.Client;

namespace GrpcAcces.Grpc;

public class UserGrpcService : IUserDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");

    Task<User> IUserDao.CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<User>> IUserDao.GetAsync(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserDao.GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserDao.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}