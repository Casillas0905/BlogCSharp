using Application.DaoInterfaces;
using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Comment;

namespace GrpcAcces.Grpc;

public class CommentGrpcService : ICommentDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private CommentGrpc.CommentGrpcClient commentGrpcClient = new CommentGrpc.CommentGrpcClient(channel);
   
    public void CreateAsync(Comment comment)
    {
        
        Console.WriteLine("grpc 1");
        CommentModelGrpc commentGrpc = new CommentModelGrpc()
        {
           Id = comment.id,
           Message = comment.message,
           PostId = comment.postId,
           UserId = comment.UserId
        }; 
        Console.WriteLine("grpc 2");
        commentGrpcClient.saveComment(commentGrpc);
        Console.WriteLine("grpc 3");
    }

    public async Task<IEnumerable<Comment>> GetByPostId(int id)
    {
        var req = new GetByPostId() { Id = id };
        using var call = commentGrpcClient.findByPostId(req);
        List<Comment> list = new List<Comment>();
        while ( await call.ResponseStream.MoveNext())
        {
            CommentModelGrpc commentGrpc = call.ResponseStream.Current;
            Comment comment = new Comment(commentGrpc.Message, commentGrpc.Id, commentGrpc.PostId, commentGrpc.UserId);
            list.Add(comment);
        }
        return list;
    }
}