using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public class JumpEngineClassAlpha : IJumpEngine
{
    public JumpEngineClassAlpha()
    {
        JumpLength = JumpEnginesJumpLength.JumpEngineClassAlphaJumpLength;
    }

    public double JumpLength { get; }
}