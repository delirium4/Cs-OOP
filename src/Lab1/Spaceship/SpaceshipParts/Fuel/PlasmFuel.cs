using System;
using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;

public class PlasmFuel : IFuel
{
    public PlasmFuel()
    {
        CostPerTick = FuelConstants.CommonFuelCostPerTick;
    }

    public double CostPerTick { get; }

    public double OverallCost(double amountOfTicks, ImpulseEngineClass impulseEngineClass)
    {
        if (impulseEngineClass == ImpulseEngineClass.CClassEngine)
        {
            return (CostPerTick * amountOfTicks) + CostPerTick;
        }
        else
        {
            return (CostPerTick * amountOfTicks * Math.Exp(amountOfTicks)) + CostPerTick;
        }
    }
}