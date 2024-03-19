using System;
using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Fuel;

public class MatterFuel : IMatterFuel
{
    public MatterFuel()
    {
        CostPerJump = FuelConstants.MatterFuelCostPerTick;
    }

    public double CostPerJump { get; }

    public double OverallCost(double amountOfTicks, JumpEngineClass jumpEngineClass)
    {
        if (jumpEngineClass == JumpEngineClass.Alpha)
        {
            return amountOfTicks * CostPerJump;
        }
        else if (jumpEngineClass == JumpEngineClass.Omega)
        {
            return amountOfTicks * CostPerJump * double.Log2(amountOfTicks * CostPerJump);
        }
        else
        {
            return Math.Pow(amountOfTicks * CostPerJump, 2);
        }
    }
}