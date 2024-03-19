namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;

public interface IUserReceiver
{
    public Message.Message? Message { get; }
    public void ReceiveMessage(Message.Message message);
}