using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.ReceiverEntities.UserReceiver;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorrectWorkOfFilterTest
{
    [Fact]
    public void StartTest()
    {
        var user = new User();
        var addressee = new UserToAddresseeAdapter(user, ImportanceLevel.NoneImportance);
        var proxyFilter = new FilterMock(addressee, false);
        Message.Message message = new MessageBuilder().WithTitle("title").WithBody("body")
            .WithImportanceLevel(ImportanceLevel.PrimaryImportance).Build();

        var topic = new Topic.Topic("Topic", proxyFilter);
        topic.SendMessage(message);

        Assert.True(proxyFilter.ResultCheck);
    }
}