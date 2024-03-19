using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserEntity;

public interface IParser
{
    public IParser? Successor { get; }
    public IEnumerable<string> ParsedString { get; }
    public ICommand DefineCommand(string command);
}