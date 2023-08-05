using Domain.Models;

namespace Application.LogicInterfaces;

public interface ILikeLogic
{
    void saveLike(Like likeModel);
    void deleteLikeByByPostLikedAndUserLiking(int PostId, int Userid);
    bool findByPostLikedAndUserLiking(int PostId, int Userid);
    int findLikesByPostLiked(int postId);
}