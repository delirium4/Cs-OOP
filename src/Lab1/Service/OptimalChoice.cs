using System;
using Itmo.ObjectOrientedProgramming.Lab1.Extensions;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class OptimalChoice
{
    private int _routeLength;

    public OptimalChoice(RouteLength routeLength)
    {
        _routeLength = routeLength.GetCoef();
    }

    public static ISpaceship OptimalChoiceInNitrineNebula(ISpaceship firstSpaceship, ISpaceship secondSpaceship)
    {
            if (firstSpaceship?.Engine is EClassEngine)
            {
                return firstSpaceship;
            }

            if (secondSpaceship?.Engine is EClassEngine)
            {
                throw new ArgumentException("Spaceships are equal");
            }
            else
            {
                if (secondSpaceship != null) return secondSpaceship;
            }

            throw new InvalidOperationException();
    }

    public ISpaceship OptimalSpaceshipInFuelWaste(ISpaceship firstSpaceship, ISpaceship secondSpaceship)
    {
        if (firstSpaceship?.FuelCost(_routeLength) < secondSpaceship?.FuelCost(_routeLength))
        {
            return firstSpaceship;
        }

        if (secondSpaceship != null)
        {
            return secondSpaceship;
        }

        throw new InvalidOperationException();
    }

    public ISpaceship OptimalSpaceshipInSucceedingCanalRoute(ISpaceship firstSpaceship, ISpaceship secondSpaceship)
    {
        if (firstSpaceship?.JumpEngine?.JumpLength >= _routeLength)
        {
            return firstSpaceship;
        }

        if (secondSpaceship?.JumpEngine?.JumpLength >= _routeLength)
        {
            if (firstSpaceship?.JumpEngine?.JumpLength > secondSpaceship?.JumpEngine?.JumpLength)
            {
                return firstSpaceship;
            }
            else if (firstSpaceship?.JumpEngine?.JumpLength < secondSpaceship?.JumpEngine?.JumpLength)
            {
                return secondSpaceship;
            }
            else
            {
                throw new ArgumentException("Spaceships are equal");
            }
        }
        else
        {
            if (secondSpaceship != null) return secondSpaceship;
        }

        throw new InvalidOperationException();
    }
}