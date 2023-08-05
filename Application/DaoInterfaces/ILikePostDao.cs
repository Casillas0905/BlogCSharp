using Domain.Models;

namespace Application.DaoInterfaces;

public interface ILikePostDao
{
    void saveLike(Like likeModel);
    void deleteLikeByByPostLikedAndUserLiking(int PostId, int Userid);
    bool findByPostLikedAndUserLiking(int PostId, int Userid);
    int findLikesByPostLiked(int postId);
}