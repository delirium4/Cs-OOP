using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; private set; }
    public IAddressee Addressee { get; private set; }

    public void SendMessage(Message.Message message)
    {
        Logger.Log("Message have been sent to Addressee");
        Addressee.ReceiveMessage(message);
    }
}