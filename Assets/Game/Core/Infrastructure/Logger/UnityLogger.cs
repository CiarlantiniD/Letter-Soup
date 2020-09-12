using System;
using UnityEngine;

public class UnityLogger : ILoggerInfrastructure
{
    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void LogError(string message)
    {
        Debug.LogError(message);
    }
}
