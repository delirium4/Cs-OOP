using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflectors;

public class FirstClassDeflector : IDeflector
{
    public FirstClassDeflector(IArmor armor)
    {
        Durability = DeflectorsDurabilityConstants.FirstClassDeflectorDurability;
        MainDeflector = null;
        Armor = armor;
    }

    public int Durability { get; private set; }
    public IDeflector? MainDeflector { get; }
    public IArmor Armor { get; }

    public void TakeDamage(int damage)
    {
        Durability -= damage;
        if (Durability < 0)
        {
            DealRemainingDamageToArmor(int.Abs(Durability));
        }
    }

    public bool IsDestroyed()
    {
        return Durability < 0;
    }

    public void DealRemainingDamageToArmor(int damage)
    {
        Armor.TakeDamage(damage);
    }
}