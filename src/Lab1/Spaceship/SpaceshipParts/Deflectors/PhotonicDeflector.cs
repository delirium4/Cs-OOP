using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;

public class PhotonicDeflector : IDeflector
{
    public PhotonicDeflector(IDeflector mainDeflector)
    {
        MainDeflector = mainDeflector;
        Armor = null;
    }

    public IDeflector MainDeflector { get; }
    public IArmor? Armor { get; }
    public int Durability { get; private set; } = DeflectorsDurabilityConstants.PhotonicDeflectorDurability;
    public void TakeDamage(int damage)
    {
            Durability -= damage;
            DealRemainingDamageToArmor(DamageConstants.ZeroDamage);
    }

    public bool IsDestroyed()
    {
        return Durability < 0;
    }

    public void DealRemainingDamageToArmor(int damage)
    {
        Armor?.TakeDamage(damage);
    }
}