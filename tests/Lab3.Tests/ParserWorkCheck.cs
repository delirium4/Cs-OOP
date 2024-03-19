using Itmo.ObjectOrientedProgramming.Lab4.ServiceEntity;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserWorkCheck
{
    [Fact]
    public void StartTest()
    {
        var service = new Service("connect C:\\\\OOP\\ -m local");
        Assert.True(service.StartExecution().ResultMessage == "Connected to C:\\\\OOP\\");
    }
}