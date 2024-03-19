using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Augur : ISpaceship
{
    public Augur(bool isPhotonicDeflectorEquipped)
    {
        Engine = new EClassEngine();
        JumpEngine = new JumpEngineClassAlpha();
        Armor = new ThirdClassArmor();
        if (isPhotonicDeflectorEquipped)
        {
            Deflector = new PhotonicDeflector(new ThirdClassDeflector(Armor));
        }
        else
        {
            Deflector = new ThirdClassDeflector(Armor);
        }

        SpaceshipWeight = SpaceshipWeightConstants.HighWeight;
        PlasmFuel = new PlasmFuel();
        MatterFuel = new MatterFuel();
        IsCrewAlive = true;
    }

    public IDeflector? Deflector { get; }
    public IJumpEngine? JumpEngine { get; }
    public IEngine Engine { get; }
    public IArmor Armor { get; }
    public IFuel PlasmFuel { get; }
    public IMatterFuel MatterFuel { get; }
    public int SpaceshipWeight { get; }
    public bool IsCrewAlive { get; private set; }

    public double FuelCost(int wayLength)
    {
        return PlasmFuel.OverallCost(Engine.TimeWasteInTicks(wayLength), ImpulseEngineClass.EClassEngine) + MatterFuel.OverallCost(Engine.TimeWasteInTicks(wayLength), JumpEngineClass.Alpha);
    }

    public bool IsNitrineEmitterEquipped()
    {
        return false;
    }

    public void TakeDamage(int damage, TypeOfObstacleDamage typeOfObstacleDamage)
    {
        if (typeOfObstacleDamage is TypeOfObstacleDamage.Antimatter
            && Deflector is PhotonicDeflector && !Deflector.IsDestroyed())
        {
            Deflector.TakeDamage(damage);
        }
        else if (typeOfObstacleDamage is TypeOfObstacleDamage.Physical && Deflector is PhotonicDeflector)
        {
            Deflector.MainDeflector?.TakeDamage(damage);
        }
        else if (typeOfObstacleDamage is TypeOfObstacleDamage.Antimatter)
        {
            IsCrewAlive = false;
        }
        else
        {
            Deflector?.TakeDamage(damage);
        }
    }

    public bool IsDestroyed()
    {
        return Armor.Durability < 0;
    }
}