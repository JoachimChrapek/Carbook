namespace Test.ConsoleApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //arrange
        Calculator calculator = new();

        
        int result = calculator.Add(3, 8);
        
        
        Assert.Equal(11, result);
    }
}