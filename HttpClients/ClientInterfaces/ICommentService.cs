using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICommentService
{
    Task CreateAsync(Comment comment);
    Task<IEnumerable<Comment>> GetByPostIdAsync(int id);
}