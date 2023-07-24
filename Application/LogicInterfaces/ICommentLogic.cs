using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ICommentLogic
{
    void CreateAsync(Comment comment);
    Task<IEnumerable<Comment>> GetByPostIdAsync(int id);
}
