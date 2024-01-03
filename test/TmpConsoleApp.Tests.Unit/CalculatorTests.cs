namespace TmpConsoleApp.Tests.Unit;

public class CalculatorTests
{
    [Fact]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers()
    {
        //arrange
        Calculator calculator = new ();

        //act
        int result = calculator.Add(8, 3);
        
        //assert
        Assert.Equal(11, result);
    }
}