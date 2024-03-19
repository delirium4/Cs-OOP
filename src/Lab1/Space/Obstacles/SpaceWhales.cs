using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class SpaceWhales : IObstacle
{
    public SpaceWhales()
    {
        TypeOfObstacleDamage = TypeOfObstacleDamage.Physical;
        Damage = DamageConstants.DamageFromSpaceWhales;
    }

    public TypeOfObstacleDamage TypeOfObstacleDamage { get; }
    public int Damage { get; }
    public int DealDamage()
    {
        return Damage;
    }
}