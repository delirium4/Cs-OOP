using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;

public interface IFuel
{
    public double CostPerTick { get; }
    public double OverallCost(double amountOfTicks, ImpulseEngineClass impulseEngineClass);
}