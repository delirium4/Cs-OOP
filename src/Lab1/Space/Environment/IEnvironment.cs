using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;

public interface IEnvironment
{
    public IEnumerable<IObstacle> ListOfObstacles { get; }
    public int EnvironmentLength { get; }
    public bool IsSuitableShip(ISpaceship spaceship);
    public bool IsSuitableObstacle(IObstacle obstacle);
    public void GetObstacle(IObstacle obstacle);
}