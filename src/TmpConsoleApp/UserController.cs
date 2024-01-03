namespace TmpConsoleApp;

public class UserController
{
    public User MainUser { get; }

    public User MainUserFriend { get; } = new User("Friend", 20, null);

    public event EventHandler ExampleEvent;
    
    public UserController()
    {
        MainUser = new User("Main User", 21, MainUserFriend);
    }

    public void NotifyExampleEvent()
    {
        ExampleEvent.Invoke(this, EventArgs.Empty);
    }
}