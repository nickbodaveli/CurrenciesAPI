using CurrencyAPI.Models;

namespace CurrencyAPI.IServices
{
    public interface ICurrencyService
    {
        Task<Currencies> Currencies();
        Task<List<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrency(string currencyCode);
    }
}
