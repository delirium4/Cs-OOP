using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyGroupAddresseeFilter : IGroupAddressee
{
    public ProxyGroupAddresseeFilter(IGroupAddressee groupAddressee)
    {
        GroupAddressee = groupAddressee;
        Addressees = GroupAddressee.Addressees;
    }

    public bool IsAccessAllowed { get; private set; } = true;
    public IGroupAddressee GroupAddressee { get; private set; }

    public IEnumerable<IAddressee>? Addressees { get; }

    public void ReceiveMessage(Message.Message message)
    {
        Filter(message);
        if (IsAccessAllowed) GroupAddressee.ReceiveMessage(message);
    }

    public void Filter(Message.Message message)
    {
        if (GroupAddressee.Addressees != null)
        {
            foreach (IAddressee addressee in GroupAddressee.Addressees)
            {
                if (message?.ImportanceLevel > addressee.ImportanceLevel) IsAccessAllowed = false;
            }
        }
    }
}