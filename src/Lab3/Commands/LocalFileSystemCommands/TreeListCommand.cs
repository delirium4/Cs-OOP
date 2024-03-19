using System;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class TreeListCommand : ILocalFileSystemCommand
{
    private StringBuilder _message;
    public TreeListCommand(FilePath filePath, int depth)
    {
        FilePath = filePath;
        Depth = depth;
        _message = new StringBuilder();
    }

    public int Depth { get; private set; }
    public FilePath FilePath { get; private set; }

    public override CommandResult Execute()
    {
        var directory = new DirectoryInfo(FilePath.AbsoluteFilePath ?? throw new ArgumentException("Filepath must be not null"));
        _message.Append(CommandOutputConstants.Directory + directory.FullName + "\n");
        int currentDepth = 1;
        foreach (FileInfo file in directory.GetFiles())
        {
            _message.Append(CommandOutputConstants.Offset + CommandOutputConstants.File + file.Name + "\n");
        }

        RecieveDirectories(currentDepth, directory);
        return new CommandResult(true, _message.ToString());
    }

    public void RecieveDirectories(int depth, DirectoryInfo directory)
    {
        if (directory != null)
        {
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                _message.Append(string.Concat(Enumerable.Repeat(CommandOutputConstants.Offset, depth)));
                _message.Append(CommandOutputConstants.Directory + directoryInfo.Name + "\n");
                if (depth < Depth) RecieveDirectories(depth + 1, directoryInfo);
            }

            foreach (FileInfo file in directory.GetFiles())
            {
                _message.Append(string.Concat(Enumerable.Repeat(CommandOutputConstants.Offset, depth)));
                _message.Append(CommandOutputConstants.File + file.Name + "\n");
            }
        }
    }
}