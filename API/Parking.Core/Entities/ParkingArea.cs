using System;

namespace Parking.Core.Entities;

public sealed class ParkingArea
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public decimal WeekdayHourlyRate { get; private set; }
    public decimal WeekendHourlyRate { get; private set; }
    public decimal DiscountPercentage { get; private set; }

    private ParkingArea()
    {
    }

    public ParkingArea(string id, string name, decimal weekdayHourlyRate, decimal weekendHourlyRate, decimal discount)
    {
        Id = id;
        Name = name;
        WeekdayHourlyRate = weekdayHourlyRate;
        WeekendHourlyRate = weekendHourlyRate;
        DiscountPercentage = discount;
    }
}