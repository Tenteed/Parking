using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking.Application.DTO;
using Parking.Application.Integrations;

namespace Parking.Application.Services;

public class PaymentCalculationService : IPaymentCalculation
{

    private readonly IParkingArea _parkingAreaService;
    
    public PaymentCalculationService(IParkingArea parkingAreaService)
    {
        _parkingAreaService = parkingAreaService;
    }
    
    public async Task<decimal> CalculatePrice(GetPaymentCalculationRequest request)
    {
        var spot = (await _parkingAreaService.GetAllAsync()).FirstOrDefault(x => x.Id == request.SpotId);

        if (spot is null)
        {
            throw new ApplicationException("Spot not found");
        }
        
        DayOfWeek[] weekendDays = [ DayOfWeek.Saturday, DayOfWeek.Sunday ];
        var duration = (request.To.TimeOfDay - request.From.TimeOfDay).TotalMinutes;
        var isWeekday = !weekendDays.Contains(request.Day.DayOfWeek);
        double result = 0;
        
        if (isWeekday)
        {
            result = duration * (double)spot.WeekdayHourlyRate;
        }
        else
        {
            result = duration * (double)spot.WeekendHourlyRate;
        }

        return (decimal)result;
    }
}