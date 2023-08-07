using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(Post dto);
    Task<IEnumerable<Post>> FindByParameters(SearchParameters searchParameters);
    Task<Post?> GetByIdAsync(int Id);
    Task<IEnumerable<Post>> GetByUserIdAsync(int UserId);
    Task<Post?> Update(Post post);
    int id { get; set; }
}