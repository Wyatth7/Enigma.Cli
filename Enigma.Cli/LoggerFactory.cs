using Microsoft.Extensions.Logging;

namespace Enigma.Cli;

public static class Logger
{
    private static ILogger? _instance;
    private static ILogger _logger
    {
        get
        {
            if (_instance is not null) return _instance;
            
            using var factory = LoggerFactory
                .Create(builder => builder.AddConsole());
        
            _instance = factory.CreateLogger("Enigma");

            return _instance;
        }
    }

    public static void Error(string message, bool exit = false, int exitCode = 1)
    {
        _logger.LogError(message);
        
        if (exit)
            Environment.Exit(exitCode);
    }
}