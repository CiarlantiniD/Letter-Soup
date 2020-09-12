using System;

public static class Logger
{
    private static ILoggerInfrastructure loggerProvider;

    public static void SetProvider(ILoggerInfrastructure provider)
    {
        loggerProvider = provider;
    }

    public static void Log(string message)
    {
        loggerProvider.Log(message);
    }

    public static void LogError(string message)
    {
        loggerProvider.LogError(message);
    }
}