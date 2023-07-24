using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    void CreateAsync(Comment comment);
    Task<IEnumerable<Comment>> GetByPostId(int id);
}
