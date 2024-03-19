using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class AugurAndStellaInMediumRangeIncreasedDensityNebula
{
    [Fact]
    public void StartTest()
    {
        var stella = new Stella(false);
        var augur = new Augur(false);
        var optimalChoice = new OptimalChoice(RouteLength.ShortRange);
        var increasedDensityNebula = new IncreasedDensityNebula(RouteLength.MediumRange);
        var stellaResults = new Service.ResultSummary(stella, increasedDensityNebula);
        var augurResults = new Service.ResultSummary(augur, increasedDensityNebula);
        stellaResults.StartSimulation();
        augurResults.StartSimulation();
        ISpaceship optimalSpaceship = optimalChoice.OptimalSpaceshipInSucceedingCanalRoute(stella, augur);
        Assert.True(optimalSpaceship is Stella);
    }
}