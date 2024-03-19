using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class VaklasAndVaklasWIthPhotonicDeflectorInIncreasedDensityNebulaAfterAntimatterBlow
{
    [Fact]
    public void StartTest()
    {
        var vaklasWithPhotonicDeflector = new Vaklas(true);
        var vaklas = new Vaklas(false);
        var increasedDensityNebula = new IncreasedDensityNebula(RouteLength.LongRange);
        var vaklasWithPhotonicDeflectorResult =
            new Service.ResultSummary(vaklasWithPhotonicDeflector, increasedDensityNebula, new AntimatterBlow(), 1);
        var vaklasResult = new Service.ResultSummary(vaklas, increasedDensityNebula, new AntimatterBlow(), 1);
        vaklasWithPhotonicDeflectorResult.StartSimulation();
        vaklasResult.StartSimulation();
        Assert.True(vaklasWithPhotonicDeflectorResult.IsCrewDead == false);
        Assert.True(vaklasResult.IsCrewDead == true);
    }
}