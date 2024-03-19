using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.ReceiverWithOutput;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorrectWorkOfMessengerTest
{
    [Fact]
    public void StartTest()
    {
        var messenger = new MessengerMock();
        var addressee = new MessengerToAddresseeAdapter(messenger, ImportanceLevel.NoneImportance);
        Message.Message message = new MessageBuilder().WithBody("body")
            .WithImportanceLevel(ImportanceLevel.NoneImportance).Build();

        var topic = new Topic.Topic("topic", addressee);
        topic.SendMessage(message);

        Assert.True(messenger.ShowMessage() == "Messenger: body");
    }
}