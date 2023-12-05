using System.Diagnostics;

namespace CarbookWebAPI.Logging;

public class TimedOperation<T> : IDisposable
{
    private readonly ILogger<T> _logger;
    private readonly LogLevel _logLevel;
    private readonly string _message;
    private readonly Stopwatch _stopwatch;
    public TimedOperation(ILogger<T> logger, LogLevel logLevel, string message)
    {
        _logger = logger;
        _logLevel = logLevel;
        _message = message;
        _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        _logger.Log(_logLevel, $"{_message} completed in {_stopwatch.ElapsedMilliseconds}ms");
    }
}