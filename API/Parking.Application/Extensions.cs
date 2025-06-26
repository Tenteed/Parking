using Microsoft.Extensions.DependencyInjection;
using Parking.Application.Integrations;
using Parking.Application.Services;

namespace Parking.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IParkingArea, ParkingAreaService>();
        services.AddSingleton<ICurrencyExchange, CurrencyExchange>();
        services.AddSingleton<IPaymentCalculation, PaymentCalculationService>();

        return services;
    }
}