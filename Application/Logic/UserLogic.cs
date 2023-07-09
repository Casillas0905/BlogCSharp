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
        User? existing = await userDao.GetByEmailAsync(user.Email);
        if (existing != null)
            throw new Exception("Email already taken!");

        ValidateData(user);
        User toCreate = new User(0,user.FirstName, user.Password, user.Email, user.LastName, user.Date);
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }


    private static void ValidateData(User user)
    {
        
    }

    Task<User?> IUserLogic.GetByEmailAsync(string email)
    {
        return userDao.GetByEmailAsync(email);
    }

    Task<User?> IUserLogic.GetByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }

    Task<User> IUserLogic.UpdateUser(User user)
    {
        return userDao.UpdateUser(user);
    }

    void IUserLogic.deleteUser(int id)
    {
        userDao.deleteUser(id);
    }
}