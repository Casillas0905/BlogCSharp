using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> FindByParameters(SearchParameters searchParameters);
    Task<Post?> GetByIdAsync(int Id);
    Task<IEnumerable<Post>> GetByUserIdAsync(int UserId);
}