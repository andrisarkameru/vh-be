using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VH.Currency;
using Moq;
using System.Net.Http;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using FluentAssertions;

namespace VH.Tests.Currency
{
    public class CurrencyTests
    {
        const string serviceBaseUrl = "http://currencylayermock.com";
        const string serviceApiKeyMock = "serviceApiKeyMock";
        CurrencyService service;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestCurrencyConversion()
        {
            decimal rateEurUSD = 4;
            decimal ammount = 10;
            var currencyResponse = new CLResponse() { quotes = new Dictionary<string, decimal>() { { "EURUSD", 4 } } };

            var mockHttp = CreateMockHttp(currencyResponse);

            service = new CurrencyService(mockHttp, serviceBaseUrl, serviceApiKeyMock);

            var eurUsdResult = await service.Convert(10, "EUR", "USD");
            eurUsdResult.Should().Be(ammount * rateEurUSD);
        }

        [Test]
        public async Task TestCurrencyConversionBackwards()
        {
            decimal rateEurUSD = 4;
            decimal ammount = 10;
            var currencyResponse = new CLResponse() { quotes = new Dictionary<string, decimal>() { { "EURUSD", 4 } } };

            var mockHttp = CreateMockHttp(currencyResponse);

            service = new CurrencyService(mockHttp, serviceBaseUrl, serviceApiKeyMock);

            var eurUsdResult = await service.Convert(10, "USD", "EUR");
            eurUsdResult.Should().Be(ammount / rateEurUSD);
        }

        [Test]
        public async Task TestCurrencyConversionUnavailable()
        {
            decimal rateEurUSD = 4;
            decimal ammount = 10;
            var currencyResponse = new CLResponse() { quotes = new Dictionary<string, decimal>() { { "EURUSD", 4 } } };

            var mockHttp = CreateMockHttp(currencyResponse);

            service = new CurrencyService(mockHttp, serviceBaseUrl, serviceApiKeyMock);

            Func<Task> act = async () => { await service.Convert(10, "USD", "Z5"); };
            act.Should().Throw<Exception>();
        }

        public HttpClient CreateMockHttp(CLResponse currencyResponse)
        {
            var json = JsonConvert.SerializeObject(currencyResponse);

            string url = serviceBaseUrl;

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json, Encoding.UTF8, "application/json");


            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            HttpClient httpClient = new HttpClient(mockHandler.Object);
            return httpClient;
        }
    }
}
