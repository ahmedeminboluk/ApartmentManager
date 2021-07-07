using ApartmentManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApartmentManager.Service.CreditCardService
{
    public class CreditCardService : ICreditCardService
    {
        private readonly HttpClient _httpClient;

        public CreditCardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> WithdrawMoney(CreditCardDto creditCardDto)
        {
            string json = JsonSerializer.Serialize(creditCardDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var uri = new Uri($"{_httpClient.BaseAddress}banking/withdrawmoney");

            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                return bool.Parse(result);
            }
            return false;
        }
    }
}
