using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public void CreateAsync(User user)
    {
        Console.WriteLine("logic called");
        User? existing = userDao.GetByEmailAsync(user.Email);
        Console.WriteLine(existing.Id);
        if (existing.Id >0)
        {
            throw new Exception("Email already taken!");
        }
        //ValidateData(user);
        Console.WriteLine("logic2 called");
        userDao.CreateAsync(user);
        Console.WriteLine("logic3 called");
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return userDao.GetByEmailAsync(email);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }

    public async Task<User> UpdateUser(User user)
    {
        return userDao.UpdateUser(user);
    }

    public void deleteUser(int id)
    {
        userDao.deleteUser(id);
    }
    
    private static void ValidateData(User user)
    {
        
    }
}