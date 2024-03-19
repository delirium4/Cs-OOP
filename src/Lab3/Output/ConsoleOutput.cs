using System;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceEntity;

namespace Itmo.ObjectOrientedProgramming.Lab4.Output;

public class ConsoleOutput
{
    private Service _service;
    private string _command;

    public ConsoleOutput()
    {
        while (true)
        {
            _command = Console.ReadLine() ?? throw new InvalidOperationException("You must write a command");
            _service = new Service(_command);
            Console.WriteLine(_service.StartExecution().ResultMessage);
        }
    }
}