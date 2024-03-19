using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public class TreeListCommandParser : IParser
{
    public IParser Successor { get; private set; } = new DisconnectCommandParser();
    public IEnumerable<string> ParsedString { get; private set; } = new List<string>();

    public ICommand DefineCommand(string command)
    {
        ParsedString = command?.Split(' ') ?? throw new InvalidOperationException();
        if (command != null &&
            command.Contains("tree", StringComparison.Ordinal) && command.Contains("list", StringComparison.Ordinal))
        {
            return new TreeListCommand(new FilePath(ParsedString.ToList()[2]), int.Parse(ParsedString.ToList()[4], NumberStyles.Integer, new NumberFormatInfo()));
        }
        else
        {
            return Successor.DefineCommand(command ?? throw new InvalidOperationException());
        }
    }
}