namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class CommandResult
{
    public CommandResult(bool isConnected, string? resultMessage)
    {
        IsConnected = isConnected;
        ResultMessage = resultMessage;
    }

    public bool IsConnected { get; private set; }
    public string? ResultMessage { get; private set; }
}