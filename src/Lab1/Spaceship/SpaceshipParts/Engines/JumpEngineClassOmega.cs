using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public class JumpEngineClassOmega : IJumpEngine
{
    public JumpEngineClassOmega()
    {
        JumpLength = JumpEnginesJumpLength.JumpEngineClassOmegaJumpLength;
    }

    public double JumpLength { get; }
}