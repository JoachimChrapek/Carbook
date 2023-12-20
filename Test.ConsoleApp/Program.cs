using FazApp.Result;

Console.WriteLine("Hello, World!");

var result1 = DoSomething();

result1.Switch(() =>
    {
        Console.WriteLine("DoSomething success");
    },
    errors =>
    {
        Console.WriteLine("DoSomething had errors");

        foreach (var error in errors)
        {
            Console.WriteLine($"[{error.Type}] {error.Code} - {error.Description}");
        }
    });



var result2 = GetSomething();

var result2Value = result2.Match(
    onValue: value =>
    {
        Console.WriteLine($"GetSomething success. Value: {value}");
        return value;
    },
    onError: errors =>
    {
        Console.WriteLine("GetSomething had errors");

        foreach (var error in errors)
        {
            Console.WriteLine($"[{error.Type}] {error.Code} - {error.Description}");
        }

        return default;
    });

return;

Result DoSomething()
{
    if (Random.Shared.Next(2) < 1)
    {
        Error error = new Error(ErrorType.Unexpected, "ConsoleApp.Random", "Random error has occured");
        return error;
    }

    return Result.Success;
}

Result<int> GetSomething()
{
    if (Random.Shared.Next(2) < 1)
    {
        Error error = new Error(ErrorType.Unexpected, "ConsoleApp.Random", "Random error has occured");
        return error;
    }

    return 5;
}