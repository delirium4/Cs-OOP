using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public class CClassEngine : IEngine
{
    public CClassEngine()
    {
        Speed = ImpulseEngineSpeedConstant.CClassEngineSpeed;
        TypeOfFuel = FuelType.FuelForImpulseEngine;
        ImpulseEngineClass = ImpulseEngineClass.CClassEngine;
    }

    public double Speed { get; }
    public FuelType TypeOfFuel { get; }
    public ImpulseEngineClass ImpulseEngineClass { get; }

    public double TimeWasteInTicks(double wayLength)
    {
        return wayLength / Speed;
    }
}