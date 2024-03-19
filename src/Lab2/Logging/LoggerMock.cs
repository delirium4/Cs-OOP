using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public static class LoggerMock
{
    public static string ShowLastLog()
    {
        return Logger.Logs.Last();
    }
}