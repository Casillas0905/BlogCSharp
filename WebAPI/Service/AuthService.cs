using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Service;

public class AuthService : IAuthService
{
    private IUserLogic userLogic;

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    
    public async Task<User> ValidateUser(string email, string password)
    {
        User? user = await userLogic.GetByEmailAsync(email);

        if (user.Id==0)
        {
            throw new Exception("User not found");
        }

        if (!user.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return user;
    }

    
    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ValidationException("Email cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        User dto = new User(0,user.FirstName, user.Password, user.Email, user.LastName, user.day, user.month, user.year, user.administrator);
        userLogic.CreateAsync(dto);
        
        return Task.CompletedTask;
    }
}