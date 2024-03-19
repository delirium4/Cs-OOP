using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class TravelShuttleAndVaklasInShortRangeRouteInSpace
{
    [Fact]
    public void StartTest()
    {
        var travelShuttle = new TravelShuttle();
        var vaklas = new Vaklas(false);
        var optimalChoice = new OptimalChoice(RouteLength.ShortRange);
        var space = new Space.Environment.UsualSpace(RouteLength.ShortRange);
        var travelShuttleResults = new ResultSummary(travelShuttle, space);
        var vaklasResults = new ResultSummary(vaklas, space);
        travelShuttleResults.StartSimulation();
        vaklasResults.StartSimulation();
        ISpaceship optimalSpaceship = optimalChoice.OptimalSpaceshipInFuelWaste(vaklas, travelShuttle);
        Assert.True(optimalSpaceship is TravelShuttle);
    }
}