using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;

public interface IMatterFuel
{
    public double CostPerJump { get; }
    double OverallCost(double amountOfTicks, JumpEngineClass jumpEngineClass);
}