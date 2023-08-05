using Application.DaoInterfaces;
using Domain.Models;
using Grpc.Net.Client;
using GrpcClasses.LikePost;
using GrpcClasses.SavePost;

namespace GrpcAcces.Grpc;

public class LikeGrpcService : ILikePostDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private LikePostGrpc.LikePostGrpcClient likeGrpcClient = new LikePostGrpc.LikePostGrpcClient(channel);
    
    public void saveLike(Like like)
    {
        LikeModelGrpc likeModelGrpc = new LikeModelGrpc()
        {
            Id = like.id,
            UserIdLiking = like.userId,
            PostIdLiked = like.postSaveId
        };
        likeGrpcClient.saveLike(likeModelGrpc);
    }

    public void deleteLikeByByPostLikedAndUserLiking(int postId, int userId)
    {
        var request = new PostUserId { UserId = userId, PostId = postId };
        likeGrpcClient.deleteById(request);
    }

    public bool findByPostLikedAndUserLiking(int postId, int userId)
    {
        var request = new PostUserId { UserId = userId, PostId = postId };
        var response = likeGrpcClient.findByPostLikedAndUserLiking(request);
        return response.Isliked;
    }

    public int findLikesByPostLiked(int postId)
    {
        var request = new GrpcClasses.LikePost.GetById() { Id = postId };
        var response = likeGrpcClient.findLikesByPostId(request);
        return response.Count_;
    }
}