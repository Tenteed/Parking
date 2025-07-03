using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Parking.Application.Integrations;

public class CurrencyExchange : ICurrencyExchange
{
    const string ApiKey = "b5e49e06655186007d49672e7ba0f89a";
    //const string ApiUri = "https://api.exchangeratesapi.io/v1/";
    const string ApiUri = "https://api.exchangeratesapi.io";
    private const string Base = "USD";
    private const string Currencies = "EUR,PLN";

    public async Task GetExchangeRates()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(ApiUri);
        var response = await client.GetFromJsonAsync<API_Obj>(string.Format(ApiUri, Base, Currencies));
    }
    
    public class API_Obj
    {
        public string? result { get; set; }
        public string? documentation { get; set; }
        public string? terms_of_use { get; set; }
        public long? time_last_update_unix { get; set; }
        public string? time_last_update_utc { get; set; }
        public long? time_next_update_unix { get; set; }
        public string? time_next_update_utc { get; set; }
        public string? base_code { get; set; }
    }
}