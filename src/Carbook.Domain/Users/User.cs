namespace Carbook.Domain.Users;

public class User
{
    public Guid Id { get; }
    public string Username { get; }

    //TODO add hashing for password
    private readonly string _password;
    
    private User() { }

    public User(Guid id, string username, string password)
    {
        Id = id;
        Username = username;
        _password = password;
    }

    public bool IsPasswordCorrect(string passwordToCheck)
    {
        return _password == passwordToCheck;
    }

    public static string NameOfPasswordProperty => nameof(_password);
}