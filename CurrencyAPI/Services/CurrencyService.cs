using CurrencyAPI.IServices;
using CurrencyAPI.Models;
using Newtonsoft.Json;
using System.Net;

namespace CurrencyAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<List<Currency>> GetAllCurrencies()
        {
            var currencyCodes = await Currencies();
            return currencyCodes.currencies.ToList();
        }

        public async Task<Currency> GetCurrency(string currencyCode)
        {
            var currencyCodes = await Currencies();
            var getCurrency = currencyCodes.currencies.Where(x => x.code == currencyCode);
            return getCurrency.FirstOrDefault();
        }

        public async Task<Currencies> Currencies()
        {
            var url = "https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json";
            var _client = new HttpClient();

            var request = await _client.GetAsync(url);
            var _response = request.Content.ReadAsStringAsync().Result;
            return (request.StatusCode == HttpStatusCode.OK) ? 
                JsonConvert.DeserializeObject<Currencies[]>(_response).FirstOrDefault() : null;
        }
    }
}
