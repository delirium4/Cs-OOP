using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

public class ThirdClassArmor : IArmor
{
    public ThirdClassArmor()
    {
        Durability = ArmorDurabilityConstants.ThirdArmorClassDurabiity;
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