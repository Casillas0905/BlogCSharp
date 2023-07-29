namespace Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string location { get; set; }

    public Location(int id, string location)
    {
        Id = id;
        this.location = location;
    }
}