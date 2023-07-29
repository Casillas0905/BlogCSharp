namespace Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string category { get; set; }

    public Category(int id, string category)
    {
        Id = id;
        this.category = category;
    }
}