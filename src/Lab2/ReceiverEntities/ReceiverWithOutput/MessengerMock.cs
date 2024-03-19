using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

public class MessengerMock : IReceiverWithOutput
{
    public Message.Message? Message { get; private set; }

    public void Print()
    {
        Console.WriteLine($"Messenger: {Message?.Body}");
    }

    public void ReceiveMessage(Message.Message message)
    {
        Message = message;
    }

    public string ShowMessage()
    {
        return $"Messenger: {Message?.Body}";
    }
}