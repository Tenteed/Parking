using Microsoft.AspNetCore.Mvc;
using Parking.Application.DTO;
using Parking.Application.Services;

namespace Parking.Controllers;

[ApiController]
[Route("payment-calculation")]
public class PaymentCalculationController : ControllerBase
{
    private readonly IPaymentCalculation _paymentCalculation;

    public PaymentCalculationController(IPaymentCalculation paymentCalculation)
    {
        _paymentCalculation = paymentCalculation;
    }
    
    [HttpGet]
    public async Task Get(GetPaymentCalculationRequest request)
    {
        await _paymentCalculation.CalculatePrice(request);
    }
}