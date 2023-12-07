// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


ServiceCollection services = new ();

services.AddSingleton<IApp, App>();
services.AddSingleton<ILogger, ConsoleLogger>();

ServiceProvider servicesProvider = services.BuildServiceProvider();

IApp app = servicesProvider.GetRequiredService<IApp>();

app.Run();





public interface IApp
{
    void Run();
}

public class App : IApp
{
    private readonly ILogger _logger;
    
    public App(ILogger logger) 
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("App started");
    }
}

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}