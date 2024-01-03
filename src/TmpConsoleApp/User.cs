namespace TmpConsoleApp;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public User? Friend { get; set; }
    
    public User(string name, int age, User? friend)
    {
        Name = name;
        Age = age;
        Friend = friend;
    }
}