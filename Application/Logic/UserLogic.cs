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

    public async Task<User> CreateAsync(User user)
    {
        User? existing = userDao.GetByEmailAsync(user.Email);
        if (existing != null)
            throw new Exception("Email already taken!");

        ValidateData(user);
        User toCreate = new User(0,user.FirstName, user.Password, user.Email, user.LastName, user.Date, user.administrator);
        
        User created = userDao.CreateAsync(toCreate);
        
        return created;
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