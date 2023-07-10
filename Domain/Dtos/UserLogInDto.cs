namespace Domain.DTOs;

public class UserLogInDto
{
    public string Email { get; init; }
    public string Password { get; init; }

    public UserLogInDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}