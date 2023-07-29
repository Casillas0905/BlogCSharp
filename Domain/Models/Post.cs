using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public int userID { get; set; }
    public string Title { get;  set;}
    public string description { get;  set; }
    public string imageUrl{get;  set;}
    public int category{get;  set;}
    public int location{get;  set;}


    public Post(int id, int userId, string title, string description, string imageUrl, int category, int location)
    {
        Id = id;
        userID = userId;
        Title = title;
        this.description = description;
        this.imageUrl = imageUrl;
        this.category = category;
        this.location = location;
    }
}









