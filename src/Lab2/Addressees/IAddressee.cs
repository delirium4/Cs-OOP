using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    public ImportanceLevel ImportanceLevel { get; }
    public void ReceiveMessage(Message.Message message);
}