using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parking.Application.Integrations;

public class CurrencyExchange : ICurrencyExchange
{
    const string ApiKey = "";
    const string ApiUri = "https://api.exchangeratesapi.io/v1/";
    private const string Base = "USD";
    private const string Currencies = "EUR,PLN";

    public async Task GetExchangeRates()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(ApiUri);
        var response = await client.GetAsync($"latest?access_key={ApiKey}&base={Base}&currencies={Currencies}");
    }
}