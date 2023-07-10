namespace Domain.Models;

public class AnswerMessage
{
    public int OwnerId { get; set; }
    public int id { get; set; }
    public string message { get; set; }
    public int postOwnerid { get; set; }

    public AnswerMessage(string message,int owner, int postOwnerid)
    {
        OwnerId = owner;
        this.message = message;
        this.postOwnerid = postOwnerid;
    }
    
    
}