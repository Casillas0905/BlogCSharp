using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(User user);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    public Task<User> getByEmail(string email);
}