using Carbook.Domain.Authentication;

namespace Carbook.Domain.Users;

public class User
{
    public Guid Id { get; }
    public string Username { get; }

    private readonly string _hashedPassword;
    
    private User() { }

    public User(Guid id, string username, string hashedPassword)
    {
        Id = id;
        Username = username;
        _hashedPassword = hashedPassword;
    }

    public bool IsPasswordCorrect(string passwordToCheck, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsPasswordCorrect(passwordToCheck, _hashedPassword);
    }

    public static string NameOfPasswordProperty => nameof(_hashedPassword);
}