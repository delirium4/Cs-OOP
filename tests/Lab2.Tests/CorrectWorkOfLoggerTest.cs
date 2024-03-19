using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorrectWorkOfLoggerTest
{
    [Fact]
    public void StartTest()
    {
        var user = new User();
        Message.Message message = new MessageBuilder().WithBody("body").WithTitle("title")
            .WithImportanceLevel(ImportanceLevel.NoneImportance).Build();
        var addressee = new UserToAddresseeAdapter(user, ImportanceLevel.NoneImportance);

        var topic = new Topic.Topic("Topic", addressee);
        topic.SendMessage(message);

        string log = LoggerMock.ShowLastLog();

        Assert.True(log == "Message have been received by user");
    }
}