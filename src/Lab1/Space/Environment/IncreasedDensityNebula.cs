using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Extensions;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;

public class IncreasedDensityNebula : IEnvironment
{
    public IncreasedDensityNebula(RouteLength lengthOfEnvironment)
    {
        EnvironmentLength = lengthOfEnvironment.GetCoef();
        ListOfObstacles = new List<IObstacle>();
    }

    public IEnumerable<IObstacle> ListOfObstacles { get; private set; }
    public int EnvironmentLength { get; }
    public bool IsSuitableShip(ISpaceship? spaceship)
    {
        if (spaceship?.JumpEngine != null && (int)spaceship.JumpEngine.JumpLength >= EnvironmentLength)
        {
            return true;
        }

        return false;
    }

    public bool IsSuitableObstacle(IObstacle obstacle)
    {
        return obstacle is AntimatterBlow;
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