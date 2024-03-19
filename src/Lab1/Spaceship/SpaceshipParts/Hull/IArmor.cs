namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull;

public interface IArmor
{
    public int Durability { get; }
    public void TakeDamage(int damage);
    public bool IsDestroyed();
}