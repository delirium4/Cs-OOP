using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public class FileRenameCommandParser : IParser
{
    public IParser Successor { get; private set; } = new TreeGoToCommandParser();
    public IEnumerable<string> ParsedString { get; private set; } = new List<string>();

    public ICommand DefineCommand(string command)
    {
        ParsedString = command?.Split(' ') ?? throw new InvalidOperationException();
        if (command != null &&
            command.Contains("rename", StringComparison.Ordinal) && command.Contains("file", StringComparison.Ordinal))
        {
            return new FileRenameCommand(new FilePath(ParsedString.ToList()[2]), ParsedString.ToList()[3]);
        }
        else
        {
            return Successor.DefineCommand(command ?? throw new InvalidOperationException());
        }
    }
}