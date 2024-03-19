using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public class TreeGoToCommandParser : IParser
{
    public IParser Successor { get; private set; } = new TreeListCommandParser();
    public IEnumerable<string> ParsedString { get; private set; } = new List<string>();

    public ICommand DefineCommand(string command)
    {
        ParsedString = command?.Split(' ') ?? throw new InvalidOperationException();
        if (command != null &&
            command.Contains("tree", StringComparison.Ordinal) && command.Contains("goto", StringComparison.Ordinal))
        {
            return new TreeGotoCommand(new FilePath(ParsedString.ToList()[2]));
        }
        else
        {
            return Successor.DefineCommand(command ?? throw new InvalidOperationException());
        }
    }
}