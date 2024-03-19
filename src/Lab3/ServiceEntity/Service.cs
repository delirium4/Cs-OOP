using Itmo.ObjectOrientedProgramming.Lab4.Commands.LocalFileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InvokerEntity;
using Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceEntity;

public class Service
{
    private IParser _parser;
    private string _stringToParse;

    public Service(string command)
    {
        _parser = new ConnectionCommandParser();
        _stringToParse = command;
    }

    public CommandResult StartExecution()
    {
        return Invoker.ExecuteCommand(_parser.DefineCommand(_stringToParse));
    }
}