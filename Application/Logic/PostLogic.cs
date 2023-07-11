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

    public Task<IEnumerable<Post>> FindByParameters(SearchParameters searchParameters)
    {
        return postDao.FindByParameters(searchParameters);
    }
    
    /*public async Task UpdateAsync(Post dto)
     {
         /*Post? existing = await postDao.GetByIdAsync(dto.Id);
 
         if (existing == null)
         {
             throw new Exception($"Post with ID {dto.Id} not found!");
         }
 
         User? user = null;
         if (dto.OwnerId != null)
         {
             user = await userDao.GetByIdAsync((int)dto.OwnerId);
             if (user == null)
             {
                 throw new Exception($"User with id {dto.OwnerId} was not found.");
             }
         }
 
         User userToUse = user ?? existing.Owner;
         string titleToUse = dto.Title ?? existing.Title;
         string message = dto.Messages ?? existing.Messages;
         
         Post updated = new (userToUse, titleToUse ,message)
         {
             Id = existing.Id,
         };
 
         ValidatePost(updated);
 
         await postDao.UpdateAsync(updated);
     }*/

    /*public async Task DeleteAsync(int id)
    {
        /*Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with ID {id} was not found!");
        }
        
        await postDao.DeleteAsync(id);
    }*/

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
    
}