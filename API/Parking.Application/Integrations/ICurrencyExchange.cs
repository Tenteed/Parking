using System.Threading.Tasks;

namespace Parking.Application.Integrations;

public interface ICurrencyExchange
{
    Task GetExchangeRates();
}