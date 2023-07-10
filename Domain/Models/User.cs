using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public int day { get; set; }
    public int month { get; set; }
    public int year { get; set; }
    
    public Boolean administrator{ get; set; }

    public User(int id, string firstName, string password, string email, string lastName, int day, int month, int year, bool administrator)
    {
        Id = id;
        FirstName = firstName;
        Password = password;
        Email = email;
        LastName = lastName;
        this.day = day;
        this.month = month;
        this.year = year;
        this.administrator = administrator;
    }
}