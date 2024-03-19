using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class ResultSummary
{
    private bool _isCrewAlive;
    private Route.Route _route;
    public ResultSummary(ISpaceship spaceship, IEnvironment environment)
    {
        IsSpaceshipDestroyedDueToEnvironmentImpact = false;
        IsDeflectorDestroyed = false;
        _isCrewAlive = true;
        IsSpaceshipDestroyedDueToLosingHull = false;
        if (environment != null)
        {
            _route = new Route.Route(environment, spaceship, null, 0, environment.EnvironmentLength);
        }
        else
        {
            throw new ArgumentException("Environment is null");
        }
    }

    public ResultSummary(
        ISpaceship spaceship,
        IEnvironment environment,
        IObstacle obstacle,
        int amountOfObstacles)
    {
        IsSpaceshipDestroyedDueToEnvironmentImpact = false;
        IsDeflectorDestroyed = false;
        _isCrewAlive = true;
        IsSpaceshipDestroyedDueToLosingHull = false;
        if (environment != null)
        {
            _route = new Route.Route(environment, spaceship, obstacle, amountOfObstacles, environment.EnvironmentLength);
        }
        else
        {
            throw new ArgumentException("Environment is null");
        }
    }

    public ResultSummary(
        ISpaceship spaceship,
        IEnvironment environment,
        IObstacle firstObstacle,
        int amountOfFirstObstacles,
        IObstacle secondObstacle,
        int amountOfSecondObstacles)
    {
        IsSpaceshipDestroyedDueToEnvironmentImpact = false;
        IsDeflectorDestroyed = false;
        _isCrewAlive = true;
        IsSpaceshipDestroyedDueToLosingHull = false;
        if (environment != null)
        {
            _route = new Route.Route(environment, spaceship, firstObstacle, secondObstacle, amountOfFirstObstacles, amountOfSecondObstacles, environment.EnvironmentLength);
        }
        else
        {
            throw new ArgumentException("Environment is null");
        }
    }

    public bool IsCrewDead => !_isCrewAlive;
    public bool IsSpaceshipDestroyedDueToEnvironmentImpact { get; private set; }
    public bool IsSpaceshipDestroyedDueToLosingHull { get; private set; }
    public bool IsDeflectorDestroyed { get; private set; }
    public bool IsSuccess()
    {
        if (!IsSpaceshipDestroyedDueToEnvironmentImpact && _isCrewAlive && !IsSpaceshipDestroyedDueToLosingHull)
        {
            return true;
        }

        return false;
    }

    public void InterimResults()
    {
        if (_route.Spaceship.Deflector != null) IsDeflectorDestroyed = _route.Spaceship.Deflector.IsDestroyed();
        _isCrewAlive = _route.Spaceship.IsCrewAlive;
        IsSpaceshipDestroyedDueToEnvironmentImpact = _route.IsShipDestroyedDueToEnvironmentImpact;
        IsSpaceshipDestroyedDueToLosingHull = _route.IsShipDestroyedDueToLosingHull;
    }

    public void StartSimulation()
    {
        _route.StartRoute();
        InterimResults();
    }
}