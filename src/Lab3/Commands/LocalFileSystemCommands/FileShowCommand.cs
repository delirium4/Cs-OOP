using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class FileShowCommand : ILocalFileSystemCommand
{
    public FileShowCommand(FilePath filePath, string mode)
    {
        Mode = mode;
        FilePath = filePath;
        FileText = new StreamReader(FilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
    }

    public string Mode { get; private set; }
    public FilePath FilePath { get; private set; }
    public StreamReader FileText { get; private set; }

    public override CommandResult Execute()
    {
        if (Mode == "console")
        {
            return new CommandResult(true, FileText.ReadToEnd());
        }

        throw new ArgumentException("You should choose correct mode");
    }
}