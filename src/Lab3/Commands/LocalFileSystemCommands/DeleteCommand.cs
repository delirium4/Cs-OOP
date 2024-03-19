using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class DeleteCommand : ILocalFileSystemCommand
{
    public DeleteCommand(FilePath filePath)
    {
        FilePath = filePath;
        File = new FileInfo(FilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
    }

    public FilePath FilePath { get; private set; }
    public FileInfo File { get; private set; }
    public override CommandResult Execute()
    {
        File.Delete();
        return new CommandResult(true, null);
    }
}