using System;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class ConnectCommand : ILocalFileSystemCommand
{
    public ConnectCommand(FilePath filePath, string mode)
    {
        FilePath = filePath;
        Mode = mode;
    }

    public FilePath FilePath { get; private set; }
    public string Mode { get; private set; }
    public override CommandResult Execute()
    {
        if (Mode == "local") return new CommandResult(true, $"Connected to {FilePath.AbsoluteFilePath}");
        throw new ArgumentException("You should choose correct mode");
    }
}