using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class AntimatterBlow : IObstacle
{
    public AntimatterBlow()
    {
        TypeOfObstacleDamage = TypeOfObstacleDamage.Antimatter;
        Damage = DamageConstants.DamageFromAntiMatterBlow;
    }

    public TypeOfObstacleDamage TypeOfObstacleDamage { get; }
    public int Damage { get; }
    public int DealDamage()
    {
        return Damage;
    }
}