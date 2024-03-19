using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public CommandResult Execute();
}