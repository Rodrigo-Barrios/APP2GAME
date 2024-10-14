using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP2GAME.Integration.CurrencyExchange.dto;

namespace APP2GAME.Integration.CurrencyExchange
{
    public class CurrencyExchangeIntegration
    {
        private readonly ILogger<CurrencyExchangeIntegration> _logger;
        private const string API_URL=" https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert";
        private const string API_KEY="46a5eb5a15mshcc12c7770901aebp10ecc8jsne67d8e53c19c";
        public CurrencyExchangeIntegration(ILogger<CurrencyExchangeIntegration> logger){
            _logger = logger;
        }
        public async Task<CurrencyExchangeResponse> GetExchangeRate(string fromCurrency, string toCurrency, decimal amount){
            string requestUrl=$"{API_URL}?from={fromCurrency}&to={toCurrency}&amount={amount}";
            var body = new CurrencyExchangeResponse();
            using (var client = new HttpClient()){
                try{
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", API_KEY);
                    var response = await client.GetAsync(requestUrl);
                    if(response.IsSuccessStatusCode){
                        body = await response.Content.ReadFromJsonAsync<CurrencyExchangeResponse>();
                        _logger.LogInformation($"Exchange rate from {fromCurrency} to {toCurrency} is {body}");
                    }
                }catch(Exception e){
                    _logger.LogError(e, "Error getting exchange rate");
                }
            }
            return body;
        }
    }
}