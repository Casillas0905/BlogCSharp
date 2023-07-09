using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public User Owner { get;private set; }
    public string Title { get; private set;}
    public string Messages { get; private set; }
    

    public Post(User owner, string title, String messages)
    {
        Owner = owner;
        Title = title;
        Messages = messages;
    }
    
   
}