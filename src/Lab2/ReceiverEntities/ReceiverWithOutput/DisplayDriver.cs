using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

public class DisplayDriver
{
    public Color Color { get; private set; }
    public Message.Message? Output { get; private set; }

    public static void ClearOutput()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void AddMessageToOutput(Message.Message? message)
    {
        Output = message;
    }

    public void ReadMessage()
    {
        Output = new Message.Message(ImportanceLevel.NoneImportance, Console.ReadLine(), Console.ReadLine());
    }
}