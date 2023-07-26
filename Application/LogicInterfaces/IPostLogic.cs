using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(Post dto);
    Task<IEnumerable<Post>> FindByParameters(SearchParameters? searchParameters);
    Task<Post?> GetByIdAsync(int Id);
    Task<IEnumerable<Post>> GetByUserIdAsync(int UserId);
    Task UpdatePost(Post post);
    Task deletePost(int id);
}