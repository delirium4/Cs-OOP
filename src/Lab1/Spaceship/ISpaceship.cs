using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public interface ISpaceship
{
    public IDeflector? Deflector { get; }
    public IJumpEngine? JumpEngine { get; }
    public IEngine Engine { get; }
    public IArmor Armor { get; }
    public IFuel PlasmFuel { get; }
    public IMatterFuel? MatterFuel { get; }
    public int SpaceshipWeight { get; }
    public bool IsCrewAlive { get; }
    public double FuelCost(int wayLength);
    public bool IsNitrineEmitterEquipped();
    public void TakeDamage(int damage, TypeOfObstacleDamage typeOfObstacleDamage);
    public bool IsDestroyed();
}