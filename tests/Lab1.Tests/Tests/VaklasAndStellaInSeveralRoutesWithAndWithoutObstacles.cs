using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class VaklasAndStellaInSeveralRoutesWithAndWithoutObstacles
{
    [Fact]
    public void StartTest()
    {
        var vaklas = new Vaklas(true);
        var stella = new Stella(false);
        var firstEnvironment = new IncreasedDensityNebula(RouteLength.MediumRange);
        var secondEnvironment = new NitrineNebula(RouteLength.MediumRange);
        var thirdEnvironment = new UsualSpace(RouteLength.ShortRange);
        var vaklasFirstResult = new ResultSummary(vaklas, firstEnvironment, new AntimatterBlow(), 2);
        var vaklasSecondResult = new ResultSummary(vaklas, secondEnvironment);
        var vaklasThirdResult = new ResultSummary(vaklas, thirdEnvironment, new SmallAsteroid(), 2, new Meteorite(), 3);
        var stellaFirstResult = new ResultSummary(stella, firstEnvironment, new AntimatterBlow(), 2);
        var stellaSecondResult = new ResultSummary(stella, secondEnvironment);
        var stellaThirdResult = new ResultSummary(stella, thirdEnvironment, new SmallAsteroid(), 2, new Meteorite(), 3);
        vaklasFirstResult.StartSimulation();
        Assert.True(vaklasFirstResult.IsSuccess());
        vaklasSecondResult.StartSimulation();
        Assert.True(vaklasSecondResult.IsSuccess());
        vaklasThirdResult.StartSimulation();
        Assert.True(vaklasThirdResult.IsSuccess() == false);
        stellaFirstResult.StartSimulation();
        Assert.True(stellaFirstResult.IsSuccess() == false);
        stellaSecondResult.StartSimulation();
        Assert.True(stellaSecondResult.IsSuccess() == false);
        stellaThirdResult.StartSimulation();
        Assert.True(stellaThirdResult.IsSuccess() == false);
    }
}