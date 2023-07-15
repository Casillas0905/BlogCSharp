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
        if (existing.Id >0)
        {
            throw new Exception("Email already taken!");
        }
        ValidateUser(user);
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
        Console.WriteLine("logic called");
        User? existing = userDao.GetByEmailAsync(user.Email);
        if (existing.Id >0)
        {
            throw new Exception("Email already taken!");
        }
        ValidateUser(user);
        return userDao.UpdateUser(user);
    }

    public void deleteUser(int id)
    {
        userDao.deleteUser(id);
    }
    
    private static void ValidateUser(User user)
    {
        string domain = "@via.dk";
        if (user.Password.Length <= 7)
        {
            throw new Exception("Password must be contain at least 8 characters");
        }
        DateTime currentDate = DateTime.Now;
        if (currentDate.Year - user.year < 18)
        {
            throw new Exception("Must be older than 18 years");
        }
        if (!(user.Email.EndsWith(domain)))
        {
            throw new Exception("Email does not have the domain @via.dk");
        }
    }
   
}