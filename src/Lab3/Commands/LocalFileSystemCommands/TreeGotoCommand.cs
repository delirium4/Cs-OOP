using Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;

public class TreeGotoCommand : ILocalFileSystemCommand
{
    public TreeGotoCommand(FilePath filePath)
    {
        FilePath = filePath;
    }

    public FilePath FilePath { get; private set; }
    public override CommandResult Execute()
    {
        return new CommandResult(true, $"{FilePath.AbsoluteFilePath}");
    }
}