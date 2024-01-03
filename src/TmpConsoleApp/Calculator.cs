namespace TmpConsoleApp;

public class Calculator
{
    public int Square(int num)
    {
        return num * num;
    }

    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    public int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    public int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    public float Divide(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException();
        }
        
        return (float)num1 / num2;
    }
}