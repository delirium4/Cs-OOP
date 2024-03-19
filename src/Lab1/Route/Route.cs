using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class Route
{
    public Route(IEnvironment environment, ISpaceship spaceship, IObstacle? obstacle, int amountOfObstacles, int routeLength)
    {
        Environment = environment;
        Spaceship = spaceship;
        FirstObstacle = obstacle;
        AmountOfFirstObstacles = amountOfObstacles;
        RouteLength = routeLength;
        SecondObstacle = null;
        AmountOfSecondObstacles = 0;
        IsShipDestroyedDueToEnvironmentImpact = false;
        IsShipDestroyedDueToLosingHull = false;
    }

    public Route(IEnvironment environment, ISpaceship spaceship, IObstacle firstObstacle, IObstacle secondObstacle, int amountOfFirstObstacles, int amountOfSecondObstacles, int routeLength)
    {
        Environment = environment;
        Spaceship = spaceship;
        FirstObstacle = firstObstacle;
        SecondObstacle = secondObstacle;
        AmountOfFirstObstacles = amountOfFirstObstacles;
        AmountOfSecondObstacles = amountOfSecondObstacles;
        RouteLength = routeLength;
        IsShipDestroyedDueToEnvironmentImpact = false;
        IsShipDestroyedDueToLosingHull = false;
    }

    public IEnvironment Environment { get; }
    public ISpaceship Spaceship { get; }
    public IObstacle? FirstObstacle { get; }
    public IObstacle? SecondObstacle { get; }
    public int AmountOfFirstObstacles { get; }
    public int AmountOfSecondObstacles { get; }
    public int RouteLength { get; }
    public bool IsShipDestroyedDueToEnvironmentImpact { get; private set; }
    public bool IsShipDestroyedDueToLosingHull { get; private set; }

    public TypeOfObstacleDamage ObstacleDamageType()
    {
        return FirstObstacle is AntimatterBlow ? TypeOfObstacleDamage.Antimatter : TypeOfObstacleDamage.Physical;
    }

    public void AddObstacle()
    {
        if (AmountOfFirstObstacles != 0 && FirstObstacle is not null)
        {
            for (int i = 0; i < AmountOfFirstObstacles; i++)
            {
                Environment?.GetObstacle(FirstObstacle);
            }
        }

        if (AmountOfSecondObstacles != 0 && SecondObstacle is not null)
        {
            for (int i = 0; i < AmountOfSecondObstacles; i++)
            {
                Environment?.GetObstacle(SecondObstacle);
            }
        }
    }

    public void SummariseAndDealDamage()
    {
        if (Environment.ListOfObstacles.All(obstacle => obstacle is SpaceWhales && Spaceship.IsNitrineEmitterEquipped()))
        {
            Spaceship.TakeDamage(DamageConstants.ZeroDamage, TypeOfObstacleDamage.Physical);
        }
        else
        {
            Spaceship.TakeDamage(Environment.ListOfObstacles.Sum(obstacle => obstacle.Damage), ObstacleDamageType());
            IsShipDestroyedDueToLosingHull = Spaceship.IsDestroyed();
        }
    }

    public void StartRoute()
    {
        if (Environment.IsSuitableShip(Spaceship))
        {
            AddObstacle();
            SummariseAndDealDamage();
        }
        else
        {
            IsShipDestroyedDueToEnvironmentImpact = true;
        }
    }
}