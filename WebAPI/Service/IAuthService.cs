using Domain.Models;

namespace WebAPI.Service;

public interface IAuthService
{
    Task<User> ValidateUser(string email, string password);
    Task RegisterUser(User user);
}