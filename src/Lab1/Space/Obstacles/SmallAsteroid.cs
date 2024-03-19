using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class SmallAsteroid : IObstacle
{
    public SmallAsteroid()
    {
        TypeOfObstacleDamage = TypeOfObstacleDamage.Physical;
        Damage = DamageConstants.DamageFromSmallAsteroids;
    }

    public TypeOfObstacleDamage TypeOfObstacleDamage { get; }
    public int Damage { get; }

    public int DealDamage()
    {
        return Damage;
    }
}