using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Extensions;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;

public class NitrineNebula : IEnvironment
{
    public NitrineNebula(RouteLength lengthOfEnvironment)
    {
        EnvironmentLength = lengthOfEnvironment.GetCoef();
        ListOfObstacles = new List<IObstacle>();
    }

    public IEnumerable<IObstacle> ListOfObstacles { get; private set; }
    public int EnvironmentLength { get; }
    public bool IsSuitableShip(ISpaceship spaceship)
    {
        if (spaceship?.Engine is not EClassEngine)
        {
            return false;
        }

        return true;
    }

    public bool IsSuitableObstacle(IObstacle obstacle)
    {
        return obstacle is SpaceWhales;
    }

    public void GetObstacle(IObstacle obstacle)
    {
        if (IsSuitableObstacle(obstacle))
        {
            ListOfObstacles = ListOfObstacles.Append(obstacle);
        }
        else
        {
            throw new ArgumentException("Incorrect obstacle for current Environment");
        }
    }
}