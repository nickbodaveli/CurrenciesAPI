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
            var currencies = await returnedCurrencies();
            return currencies.ToList();
        }

        public async Task<Currency> GetCurrency(string currencyCode)
        {
            var currencyCodes = await returnedCurrencies();
            var getCurrency = currencyCodes.Where(x => x.code == currencyCode);
            return getCurrency.FirstOrDefault();
        }

        public async Task<List<Currency>> returnedCurrencies()
        {
            var currencyCodes = await Currencies();

            for (int i = 0; i < currencyCodes.currencies.Count; i++)
            {
                if (currencyCodes.currencies[i].validFromDate.DayOfWeek == DayOfWeek.Friday)
                {
                    while (currencyCodes.currencies[i].validFromDate.DayOfWeek != DayOfWeek.Monday)
                    {
                        currencyCodes.currencies[i].validFromDate = currencyCodes.currencies[i].validFromDate.AddDays(1);
                    }
                }
            }
            return currencyCodes.currencies;
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
