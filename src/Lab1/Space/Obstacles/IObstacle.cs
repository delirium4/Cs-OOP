namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public interface IObstacle
{
    public TypeOfObstacleDamage TypeOfObstacleDamage { get; }
    public int Damage { get; }
    public int DealDamage();
}