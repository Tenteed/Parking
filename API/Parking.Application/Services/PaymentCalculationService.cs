using System.Threading.Tasks;
using Parking.Application.DTO;
using Parking.Application.Integrations;

namespace Parking.Application.Services;

public class PaymentCalculationService : IPaymentCalculation
{
    private readonly ICurrencyExchange _currencyExchange;

    public PaymentCalculationService(ICurrencyExchange currencyExchange)
    {
        _currencyExchange = currencyExchange;
    }
    
    public async Task<decimal> CalculatePrice(GetPaymentCalculationRequest request)
    {
        await _currencyExchange.GetExchangeRates();

        return 0;
    }
}