namespace Domain.Models;

public class SearchParameters
{
    public String? title { get; set; }
    public String? location{ get; set; }
    public String? category{ get;  set;}

    public SearchParameters(string? title, string? location, string? category)
    {
        this.title = title;
        this.location = location;
        this.category = category;
    }
}