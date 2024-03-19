using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayToAddresseeAdapter : IAddressee
{
    public DisplayToAddresseeAdapter(IReceiverWithOutput display, ImportanceLevel importanceLevel)
    {
        Display = display;
        ImportanceLevel = importanceLevel;
    }

    public IReceiverWithOutput Display { get; private set; }
    public ImportanceLevel ImportanceLevel { get; }
    public void ReceiveMessage(Message.Message message)
    {
        Logger.Log("Display-addressee received message");
        Display.ReceiveMessage(message);
    }
}