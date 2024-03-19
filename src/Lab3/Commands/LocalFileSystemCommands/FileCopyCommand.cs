using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class FileCopyCommand : ILocalFileSystemCommand
{
    public FileCopyCommand(FilePath sourcePath, FilePath destinationPath)
    {
        FilePath = sourcePath;
        DestinationFilePath = destinationPath;
        SourceFile = new FileInfo(FilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
        DestinationFile = new FileInfo(DestinationFilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
    }

    public FilePath FilePath { get; private set; }
    public FilePath DestinationFilePath { get; private set; }
    public FileInfo SourceFile { get; private set; }
    public FileInfo DestinationFile { get; private set; }

    public override CommandResult Execute()
    {
        SourceFile.CopyTo(DestinationFile.FullName);
        return new CommandResult(true, null);
    }
}