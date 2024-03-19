using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public class ConnectionCommandParser : IParser
{
    public IParser Successor { get; private set; } = new FileShowCommandParser();
    public IEnumerable<string> ParsedString { get; private set; } = new List<string>();

    public ICommand DefineCommand(string command)
    {
        ParsedString = command?.Split(' ') ?? throw new InvalidOperationException();
        if (command != null &&
            command.Contains("connect", StringComparison.Ordinal))
        {
            return new ConnectCommand(new FilePath(ParsedString.ToList()[1]), ParsedString.Last());
        }
        else
        {
            return Successor.DefineCommand(command ?? throw new InvalidOperationException());
        }
    }
}