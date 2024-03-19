using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InvokerEntity;

public static class Invoker
{
    public static CommandResult ExecuteCommand(ICommand command)
    {
       return command?.Execute() ?? throw new InvalidOperationException("You must write a command");
    }
}