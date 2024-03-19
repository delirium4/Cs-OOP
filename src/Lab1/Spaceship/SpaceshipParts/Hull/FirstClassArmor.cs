using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

public class FirstClassArmor : IArmor
{
    public FirstClassArmor()
    {
        Durability = ArmorDurabilityConstants.FirstArmorClassDurability;
    }

    public int Durability { get; private set; }
    public void TakeDamage(int damage)
    {
        Durability -= damage;
    }

    public bool IsDestroyed()
    {
        return Durability < 0;
    }
}