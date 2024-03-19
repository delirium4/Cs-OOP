using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class Meteorite : IObstacle
{
    public Meteorite()
    {
        TypeOfObstacleDamage = TypeOfObstacleDamage.Physical;
        Damage = DamageConstants.DamageFromMeteorites;
    }

    public TypeOfObstacleDamage TypeOfObstacleDamage { get; }
    public int Damage { get; }

    public int DealDamage()
    {
        return Damage;
    }
}