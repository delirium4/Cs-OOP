namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class DisconnectCommand : ILocalFileSystemCommand
{
    public override CommandResult Execute()
    {
        return new CommandResult(false, "Disconnected successfully");
    }
}