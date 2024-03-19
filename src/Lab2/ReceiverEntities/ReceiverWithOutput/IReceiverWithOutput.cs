namespace Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;

public interface IReceiverWithOutput
{
    public Message.Message? Message { get; }
    public void Print();
    public void ReceiveMessage(Message.Message message);
}