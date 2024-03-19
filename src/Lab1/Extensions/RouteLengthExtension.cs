using System;
using Itmo.ObjectOrientedProgramming.Lab1.Route;

namespace Itmo.ObjectOrientedProgramming.Lab1.Extensions;

public static class RouteLengthExtension
{
    public static int GetCoef(this RouteLength routeLength) => routeLength switch
    {
        RouteLength.None => 0,
        RouteLength.ShortRange => 200,
        RouteLength.MediumRange => 400,
        RouteLength.LongRange => 600,
        _ => throw new ArgumentOutOfRangeException(nameof(routeLength), routeLength, null),
    };
}