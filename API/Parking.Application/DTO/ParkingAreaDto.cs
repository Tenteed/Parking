using System;
using Parking.Core.Entities;

namespace Parking.Application.DTO;

public class ParkingAreaDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal WeekdayHourlyRate { get; set; }
    public decimal WeekendHourlyRate { get; set; }
    public decimal DiscountPercentage { get; set; }

    public ParkingAreaDto()
    {
    }

    public ParkingAreaDto(string id, string name, decimal weekdayHourlyRate, decimal weekendHourlyRate,
        decimal discount)
    {
        Id = id;
        Name = name;
        WeekdayHourlyRate = weekdayHourlyRate;
        WeekendHourlyRate = weekendHourlyRate;
        DiscountPercentage = discount;
    }
}