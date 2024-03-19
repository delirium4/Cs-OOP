using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;

public interface IDeflector
{
    public int Durability { get; }
    public IDeflector? MainDeflector { get; }
    public IArmor? Armor { get; }
    public void TakeDamage(int damage);
    public bool IsDestroyed();
    public void DealRemainingDamageToArmor(int damage);
}