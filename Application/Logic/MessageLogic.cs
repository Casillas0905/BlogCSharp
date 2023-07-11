using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class MessageLogic : IMessageLogic
{

    private readonly IMessageDao messageDao;
    private readonly IUserDao userDao;
    private readonly IPostDao postDao;

    public MessageLogic(IMessageDao messageDao, IUserDao userDao, IPostDao postDao)
    {
        this.messageDao = messageDao;
        this.userDao = userDao;
        this.postDao = postDao;
    }

    /*public async Task<AnswerMessage> CreateAsync(MessageCreationDto messageCreationDto)
    {
        User? user = await userDao.GetByIdAsync(messageCreationDto.Ownerid);
        if (user == null)
        {
            throw new Exception($"User with id {messageCreationDto.Ownerid} was not found.");
        }

        Post? post = await postDao.GetByIdAsync(messageCreationDto.PostOwnerId);
        if (post == null)
        {
            throw new Exception($"User with id {messageCreationDto.PostOwnerId} was not found.");
        }
        AnswerMessage message = new AnswerMessage(messageCreationDto.message,user.Id, messageCreationDto.PostOwnerId);
            
        ValidateMessage(message);
        AnswerMessage created = await messageDao.CreateAsync(message);
        return created;
    }



    public async Task<AnswerMessage?> GetByIdAsync(int id)
    {
        AnswerMessage? message = await messageDao.GetByIdAsync(id);
        if (message == null)
        {
            throw new Exception($"Message with id {id} not found");
        }

        return message;
    }

    public Task<IEnumerable<AnswerMessage>> GetByPostIdAsync(int id)
    {
        return messageDao.GetByPostId(id);
    }

    public void ValidateMessage(AnswerMessage message)
    {
        if(string.IsNullOrEmpty(message.message))throw new Exception("Title cannot be empty.");
    }*/
  
    public Task<AnswerMessage?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnswerMessage>> GetByPostIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
