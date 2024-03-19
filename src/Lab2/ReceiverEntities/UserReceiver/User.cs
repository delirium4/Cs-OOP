using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;

public class User : IUserReceiver
{
    public Message.Message? Message { get; private set; }
    public void ReceiveMessage(Message.Message message)
    {
        Message = message;
        Logger.Log("Message have been received by user");
    }
}