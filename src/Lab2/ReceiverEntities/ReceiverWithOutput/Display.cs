using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

public class Display : IReceiverWithOutput
{
    public Message.Message? Message { get; private set; }
    public DisplayDriver? DisplayDriver { get; private set; }

    public void Print()
    {
        DisplayDriver?.AddMessageToOutput(Message);
        Console.WriteLine(DisplayDriver?.Output);
        DisplayDriver.ClearOutput();
    }

    public void ReceiveMessage(Message.Message message)
    {
        Message = message;
        Logger.Log("Message have been received on Display");
    }

    public void Print(Color color)
    {
        DisplayDriver?.SetColor(color);
        DisplayDriver?.AddMessageToOutput(Message);
        if (DisplayDriver != null)
        {
            Crayon.Output.Rgb(DisplayDriver.Color.R, DisplayDriver.Color.G, DisplayDriver.Color.B)
                .Text(Message?.Title + "\n" + Message?.Body);
        }
    }
}