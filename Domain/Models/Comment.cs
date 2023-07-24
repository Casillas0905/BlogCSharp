namespace Domain.Models;

public class Comment
{
    public String message { get; set; }
    public int id { get; set; }
    public int postId { get; set; }
    public int UserId { get; set; }

    public Comment(string message, int id, int postId, int userId)
    {
        this.message = message;
        this.id = id;
        this.postId = postId;
        UserId = userId;
    }

    public Comment()
    {
    }
}