using System;

namespace Parking.Application.DTO;

public class GetPaymentCalculationRequest
{
    public string SpotId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public DateTime Day { get; set; }
}