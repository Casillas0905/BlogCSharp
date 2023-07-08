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

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    public Task<User> getByEmail(string email)
    {
        return userDao.GetByEmailAsync(email);
    }


    private static void ValidateData(User user)
    {
        
    }
}