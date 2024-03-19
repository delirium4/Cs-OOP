using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class FilterMock : IAddressee
{
    public FilterMock(IAddressee addressee, bool result)
    {
        ProxyFilter = new ProxyFilter(addressee);
        ImportanceLevel = ImportanceLevel.NoneImportance;
        CorrectResult = result;
    }

    public bool CorrectResult { get; private set; }
    public bool ResultCheck { get; private set; }
    public ProxyFilter ProxyFilter { get; private set; }
    public ImportanceLevel ImportanceLevel { get; }
    public void ReceiveMessage(Message.Message message)
    {
        ProxyFilter.ReceiveMessage(message);
        if (CorrectResult == ProxyFilter.IsAccessAllowed) ResultCheck = true;
    }
}