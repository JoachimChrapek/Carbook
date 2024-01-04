namespace Carbook.Domain.Authentication;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool IsPasswordCorrect(string password, string hashedPassword);
}