namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;

public class ProxyUser : IUserReceiver
{
    public ProxyUser(IUserReceiver user)
    {
        User = user;
        Message = User.Message;
    }

    public bool IsRead { get; private set; }
    public bool IsExceptionMustBeSent { get; private set; }
    public IUserReceiver User { get; private set; }
    public Message.Message? Message { get; }

    public void ReceiveMessage(Message.Message message)
    {
        IsRead = false;
        User.ReceiveMessage(message);
    }

    public void ViewMessage()
    {
        if (IsRead) IsExceptionMustBeSent = true;
        IsRead = true;
    }
}