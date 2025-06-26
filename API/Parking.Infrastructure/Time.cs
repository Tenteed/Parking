using System;
using Parking.Core.Interfaces;

namespace Parking.Infrastructure;

public class Time : ITime
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}