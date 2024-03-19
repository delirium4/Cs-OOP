using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyFilter : IAddressee
{
    private IAddressee _addressee;
    public ProxyFilter(IAddressee addressee)
    {
        _addressee = addressee;
        ImportanceLevel = _addressee.ImportanceLevel;
    }

    public bool IsAccessAllowed { get; private set; } = true;
    public ImportanceLevel ImportanceLevel { get; private set; }
    public void ReceiveMessage(Message.Message message)
    {
        Filter(message);
        if (IsAccessAllowed) _addressee.ReceiveMessage(message);
    }

    public void Filter(Message.Message message)
    {
        if (message?.ImportanceLevel > ImportanceLevel) IsAccessAllowed = false;
    }
}