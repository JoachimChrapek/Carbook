using FluentAssertions;
using Xunit.Abstractions;

namespace TmpConsoleApp.Tests.Unit;

public class CalculatorTests : IDisposable, IAsyncLifetime
{
    //system under test
    private readonly Calculator _sut = new();

    private readonly ITestOutputHelper _outputHelper;

    public CalculatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("CTOR");
    }

    public void Dispose()
    {
        _outputHelper.WriteLine("Dispose");
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 4, 4)]
    [InlineData(0, -6, -6)]
    [InlineData(1, -6, -5)]
    [InlineData(1, 6, 7)]
    [InlineData(5, 6, 11)]
    [InlineData(-5, 6, 1)]
    [InlineData(-5, -6, -11)]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int a, int b, int expected)
    {
        //arrange
        // using _sut
        
        //act
        int result = _sut.Add(a, b);
        
        //assert
        //Assert.Equal(expected, result);
        result.Should().Be(expected);
        
        _outputHelper.WriteLine("Add test");
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 4, 0)]
    [InlineData(0, -6, 0)]
    [InlineData(1, -6, -6)]
    [InlineData(1, 6, 6)]
    [InlineData(5, 6, 30)]
    [InlineData(-5, 6, -30)]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenTwoNumbersAreIntegers(int a, int b, int expected)
    {
        //arrange
        // using _sut
        
        //act
        int result = _sut.Multiply(a, b);
        
        //assert
        //Assert.Equal(expected, result);
        result.Should().Be(expected);
        
        _outputHelper.WriteLine("Multiply test");
    }

    [Fact]
    public void Divide_ShouldThrowException_WhenDividingByZero()
    {
        Action result = () => _sut.Divide(10, 0);

        result.Should().Throw<DivideByZeroException>();
    }

    public Task InitializeAsync()
    {
        _outputHelper.WriteLine("InitializeAsync");
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _outputHelper.WriteLine("DisposeAsync");
        return Task.CompletedTask;
    }
}