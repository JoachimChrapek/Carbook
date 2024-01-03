using FluentAssertions;
using FluentAssertions.Events;

namespace TmpConsoleApp.Tests.Unit;

public class UserControllerTests
{
    private readonly UserController _sut = new();
    
    //TODO How to name this test?
    [Fact]
    public void User_ShouldBeMainUser_WhenAlways()
    {
        User expected = new User("Main User", 21, _sut.MainUserFriend);
        User user = _sut.MainUser;

        user.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void NotifyExampleEvent_ShouldInvokeExampleEvent_WhenMethodIsCalled()
    {
        IMonitor<UserController>? monitor = _sut.Monitor();
        
        _sut.NotifyExampleEvent();

        monitor.Should().Raise(nameof(UserController.ExampleEvent));
    }
}