using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        User? user = userDao.GetByIdAsync(post.userID);
        Console.WriteLine(post.userID);
        if (user.Id==0)
        {
            throw new Exception($"User with id {post.userID} was not found.");
        }

        ValidatePost(post);

        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> FindByParameters(SearchParameters? searchParameters)
    {
        return postDao.FindByParameters(searchParameters);
    }
    
    public async Task<Post> GetByIdAsync(int id)
    {
        Post? model = await postDao.GetByIdAsync(id);
        if (model.Id==0)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return new Post(model.Id,model.userID, model.Title, model.description,model.imageUrl, model.category, model.location);
    }

    public Task<IEnumerable<Post>> GetByUserIdAsync(int UserId)
    {
        Console.WriteLine("Logic");
        return postDao.GetByUserIdAsync(UserId);
    }

    private void ValidatePost(Post dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
    }

    public async Task UpdatePost(Post post)
    {
        Post? existing = await postDao.GetByIdAsync(post.Id);
 
        if (existing == null)
        {
            throw new Exception($"Post with ID {post.Id} not found!");
        }
        ValidatePost(post);
 
        postDao.UpdatePost(post);
    }

    public async Task deletePost(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with ID {id} was not found!");
        }
        postDao.deletePost(id);
    }
}