using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VH.Currency
{
    public class CurrencyService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;
        private readonly string _accessKey;

        public CurrencyService(HttpClient http, string baseUrl, string accessKey)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _accessKey = accessKey ?? throw new ArgumentNullException(nameof(accessKey));
        }

        public async Task<decimal> Convert(decimal ammount, string from, string to)
        {
            var rate = await GetRate(from, to);
            var result = ammount * rate;

            return result;
        }

        public async Task<decimal> GetRate(string from, string to)
        {
            var url = $"{_baseUrl}/live?access_key={_accessKey}& currencies={from},{to}";
            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CLResponse>(jsonResult);
            if (result.quotes.ContainsKey($"{from}{to}"))
            {
                return result.quotes[$"{from}{to}"];
            }
            else if (result.quotes.ContainsKey($"{to}{from}"))
            {
                return 1/result.quotes[$"{to}{from}"];
            }
            else
            {
                throw new Exception($"Currency exchange rate for {from} {to} unavailable");
            }
        }
    }
}
