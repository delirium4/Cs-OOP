using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public class DisconnectCommandParser : IParser
{
    public IParser? Successor { get; private set; }
    public IEnumerable<string> ParsedString { get; private set; } = new List<string>();

    public ICommand DefineCommand(string command)
    {
        ParsedString = command?.Split(' ') ?? throw new InvalidOperationException();
        if (command != null &&
            command.Contains("disconnect", StringComparison.Ordinal))
        {
            return new DisconnectCommand();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}