using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class VaklasAndAugurAndMeredianInNitrineNebulaAfterSpaceWhaleAttack
{
    [Fact]
    public void StartTest()
    {
        var vaklas = new Vaklas(false);
        var augur = new Augur(false);
        var meredian = new Meredian(false);
        var environment = new NitrineNebula(RouteLength.MediumRange);
        var vaklasResult = new Service.ResultSummary(vaklas, environment, new SpaceWhales(), 1);
        var augurResult = new Service.ResultSummary(augur, environment, new SpaceWhales(), 1);
        var meredianResult = new Service.ResultSummary(meredian, environment, new SpaceWhales(), 1);
        vaklasResult.StartSimulation();
        augurResult.StartSimulation();
        meredianResult.StartSimulation();
        Assert.True(vaklasResult.IsSpaceshipDestroyedDueToLosingHull);
        Assert.True(augurResult.IsDeflectorDestroyed);
        Assert.True(meredianResult.IsSuccess());
    }
}