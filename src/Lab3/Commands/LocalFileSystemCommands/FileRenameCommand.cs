using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class FileRenameCommand : ILocalFileSystemCommand
{
    public FileRenameCommand(FilePath filePath, string name)
    {
        FilePath = filePath;
        Name = name;
        File = new FileInfo(FilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
    }

    public FilePath FilePath { get; }
    public FileInfo File { get; private set; }
    public string Name { get; private set; }

    public override CommandResult Execute()
    {
        File.MoveTo(File.Directory + Name + File.Extension);
        return new CommandResult(true, null);
    }
}