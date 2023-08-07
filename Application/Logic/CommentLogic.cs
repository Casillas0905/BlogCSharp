using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{

    private readonly ICommentDao commentDao;
    private readonly IPostDao postDao;

    public CommentLogic(ICommentDao commentDao,IPostDao postDao)
    {
        this.commentDao = commentDao;
        this.postDao = postDao;
    }

    public async void CreateAsync(Comment comment)
    {
        Post? post = await postDao.GetByIdAsync(comment.postId);
        if (post == null)
        {
            throw new Exception($"Post with id {comment.postId} was not found.");
        }
        
        ValidateMessage(comment);
        commentDao.CreateAsync(comment);
    }

    public Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        return commentDao.GetByPostId(id);
    }

    public void ValidateMessage(Comment comment)
    {
        if(string.IsNullOrEmpty(comment.message))throw new Exception("Message cannot be empty.");
    }
  
 
}
