namespace Domain.DTOs;

public class UserCreationDto
{
    public string FirsName { get;}
    public string Password { get; }
    public string Email { get; }
    public string Name { get; }
    public int SecurityLevel { get; }

    public UserCreationDto(string firsName, string password, string email, string name, int securityLevel)
    {
        FirsName = firsName;
        Password = password;
        Email = email;
        Name = name;
        SecurityLevel = securityLevel;
    }
}