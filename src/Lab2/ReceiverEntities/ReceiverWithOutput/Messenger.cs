using System;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

public class Messenger : IReceiverWithOutput
{
    public Message.Message? Message { get; private set; }

    public void Print()
    {
        Console.WriteLine($"Messanger: \n {Message?.Title} \n {Message?.Body}");
    }

    public void ReceiveMessage(Message.Message message)
    {
        Message = message;
        Logger.Log("Message have been received on Messanger");
    }
}