namespace Domain.Models;

public class Like
{
    
    public int id {get;  set;}
    public int userId { get; set; }
    public int postSaveId { get;  set;}

    public Like(int id, int userId, int postSaveId)
    {
        this.id = id;
        this.userId = userId;
        this.postSaveId = postSaveId;
    }

    public Like()
    {
    }
}