using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public interface IEngine
{
    public double Speed { get; }
    public FuelType TypeOfFuel { get; }
    public ImpulseEngineClass ImpulseEngineClass { get; }
    public double TimeWasteInTicks(double wayLength);
}