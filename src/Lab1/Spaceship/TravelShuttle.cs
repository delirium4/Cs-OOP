using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class TravelShuttle : ISpaceship
{
    public TravelShuttle()
    {
        Deflector = null;
        JumpEngine = null;
        Engine = new CClassEngine();
        Armor = new FirstClassArmor();
        SpaceshipWeight = SpaceshipWeightConstants.LowWeight;
        PlasmFuel = new PlasmFuel();
        MatterFuel = null;
        IsCrewAlive = true;
    }

    public IDeflector? Deflector { get; }
    public IJumpEngine? JumpEngine { get; }
    public IEngine Engine { get; }
    public IArmor Armor { get; }
    public IFuel PlasmFuel { get; }
    public IMatterFuel? MatterFuel { get; }
    public int SpaceshipWeight { get; }
    public bool IsCrewAlive { get; private set; }

    public double FuelCost(int wayLength)
    {
        return PlasmFuel.OverallCost(wayLength, ImpulseEngineClass.CClassEngine);
    }

    public bool IsNitrineEmitterEquipped()
    {
        return false;
    }

    public void TakeDamage(int damage, TypeOfObstacleDamage typeOfObstacleDamage)
    {
        if (typeOfObstacleDamage == TypeOfObstacleDamage.Antimatter)
        {
            IsCrewAlive = false;
        }
        else
        {
            Armor.TakeDamage(damage);
        }
    }

    public bool IsDestroyed()
    {
        return Armor.IsDestroyed();
    }
}