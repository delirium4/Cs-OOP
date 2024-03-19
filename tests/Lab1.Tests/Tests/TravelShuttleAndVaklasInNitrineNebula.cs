using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class TravelShuttleAndVaklasInNitrineNebula
{
    [Fact]
    public void StartTest()
    {
        var travelShuttle = new TravelShuttle();
        var vaklas = new Vaklas(false);
        var nitrineNebula = new NitrineNebula(RouteLength.ShortRange);
        var travelShuttleResults = new ResultSummary(travelShuttle, nitrineNebula);
        var vaklasResults = new ResultSummary(vaklas, nitrineNebula);
        travelShuttleResults.StartSimulation();
        vaklasResults.StartSimulation();
        ISpaceship optimalSpaceship = OptimalChoice.OptimalChoiceInNitrineNebula(vaklas, travelShuttle);
        Assert.True(optimalSpaceship is Vaklas);
    }
}