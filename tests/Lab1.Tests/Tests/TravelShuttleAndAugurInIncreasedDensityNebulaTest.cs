using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class TravelShuttleAndAugurInIncreasedDensityNebulaTest
{
    [Fact]
    public void StartTest()
    {
        var travelShuttle = new TravelShuttle();
        var augur = new Augur(false);
        var increasedDensityNebula = new IncreasedDensityNebula(RouteLength.MediumRange);
        var travelShuttleResults = new Service.ResultSummary(travelShuttle, increasedDensityNebula);
        var augurResults = new Service.ResultSummary(augur, increasedDensityNebula);
        travelShuttleResults.StartSimulation();
        augurResults.StartSimulation();
        Assert.True(travelShuttleResults.IsSuccess() == false);
        Assert.True(augurResults.IsSuccess() == false);
    }
}