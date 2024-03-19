using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerToAddresseeAdapter : IAddressee
{
    public MessengerToAddresseeAdapter(IReceiverWithOutput messenger, ImportanceLevel importanceLevel)
    {
        Messenger = messenger;
        ImportanceLevel = importanceLevel;
    }

    public IReceiverWithOutput Messenger { get; private set; }

    public ImportanceLevel ImportanceLevel { get; private set; }

    public void ReceiveMessage(Message.Message message)
    {
        Messenger.ReceiveMessage(message);
        Logger.Log("Messanger-addressee received message");
    }
}