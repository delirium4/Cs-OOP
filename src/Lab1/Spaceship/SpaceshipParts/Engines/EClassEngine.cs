using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public class EClassEngine : IEngine
{
    public EClassEngine()
    {
        Speed = ImpulseEngineSpeedConstant.EClassEngineSpeed;
        ImpulseEngineClass = ImpulseEngineClass.EClassEngine;
        TypeOfFuel = FuelType.FuelForImpulseEngine;
    }

    public double Speed { get; }
    public FuelType TypeOfFuel { get; }
    public ImpulseEngineClass ImpulseEngineClass { get; }

    public double TimeWasteInTicks(double wayLength)
    {
        return wayLength / Speed;
    }
}