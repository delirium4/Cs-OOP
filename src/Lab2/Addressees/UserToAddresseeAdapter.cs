using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserToAddresseeAdapter : IAddressee
{
    public UserToAddresseeAdapter(User user, ImportanceLevel importanceLevel)
    {
        User = user;
        ImportanceLevel = importanceLevel;
    }

    public User User { get; private set; }
    public ImportanceLevel ImportanceLevel { get; }
    public void ReceiveMessage(Message.Message message)
    {
        Logger.Log("User-addressee received message");
        User.ReceiveMessage(message);
    }
}