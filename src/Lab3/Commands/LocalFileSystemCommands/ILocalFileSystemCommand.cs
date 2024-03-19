namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public abstract class ILocalFileSystemCommand : ICommand
{
    public abstract CommandResult Execute();
}