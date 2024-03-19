using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IGroupAddressee
{
    public IEnumerable<IAddressee>? Addressees { get; }
    public void ReceiveMessage(Message.Message message);
}