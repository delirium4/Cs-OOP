using Itmo.ObjectOrientedProgramming.Lab1.CharacteristicConstants;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engines;

public class JumpEngineClassGamma : IJumpEngine
{
    public JumpEngineClassGamma()
    {
        JumpLength = JumpEnginesJumpLength.JumpEngineClassGammaJumpLength;
    }

    public double JumpLength { get; }
}