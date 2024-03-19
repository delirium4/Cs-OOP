using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ExceptionAfterTryingToMarkMessageAsReadTwice
{
    [Fact]
    public void StartTest()
    {
        var user = new User();
        var addressee = new UserToAddresseeAdapter(user, ImportanceLevel.PrimaryImportance);
        Message.Message message = new MessageBuilder().WithTitle("title").WithBody("body")
            .WithImportanceLevel(ImportanceLevel.NoneImportance).Build();

        var topic = new Topic.Topic("Topic", addressee);
        topic.SendMessage(message);

        var proxyUser = new ProxyUser(user);
        proxyUser.ViewMessage();
        proxyUser.ViewMessage();

        Assert.True(proxyUser.IsExceptionMustBeSent);
    }
}