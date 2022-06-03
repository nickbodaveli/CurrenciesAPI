using CurrencyAPI.IServices;
using CurrencyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;
        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await _service.GetAllCurrencies();
            return Ok(currencies);
        }

        [HttpGet("{currencyCode}")]
        public async Task<IActionResult> Get(string currencyCode)
        {
            var currency = await _service.GetCurrency(currencyCode);
            return Ok(currency);
        }
    }
}
