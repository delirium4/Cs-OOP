using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public static class Logger
{
    public static IEnumerable<string> Logs { get; private set; } = new List<string>();
    public static void Log(string log)
    {
        Logs = Logs.Append(log);
    }
}