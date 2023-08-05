using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class LikeLogic : ILikeLogic
{
    private readonly ILikePostDao likePostDao;

    public LikeLogic(ILikePostDao likePostDao)
    {
        this.likePostDao = likePostDao;
    }

    public void saveLike(Like likeModel)
    {
        likePostDao.saveLike(likeModel);
    }

    public void deleteLikeByByPostLikedAndUserLiking(int PostId, int Userid)
    {
        likePostDao.deleteLikeByByPostLikedAndUserLiking(PostId,Userid);
    }

    public bool findByPostLikedAndUserLiking(int PostId, int Userid)
    {
        return likePostDao.findByPostLikedAndUserLiking(PostId,Userid);
    }

    public int findLikesByPostLiked(int postId)
    {
        return likePostDao.findLikesByPostLiked(postId);
    }
}