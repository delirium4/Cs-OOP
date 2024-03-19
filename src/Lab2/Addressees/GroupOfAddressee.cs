using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupOfAddressee : IGroupAddressee
{
    public IEnumerable<IAddressee>? Addressees { get; private set; }

    public void ReceiveMessage(Message.Message message)
    {
        if (Addressees != null)
        {
            foreach (IAddressee addressee in Addressees)
            {
                addressee.ReceiveMessage(message);
            }

            Logger.Log("All addressees in group received message");
        }
    }

    public void AddAddressee(IAddressee addressee)
    {
        Addressees = Addressees?.Append(addressee);
    }
}