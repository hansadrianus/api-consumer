using ApplicationUI.Models.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public class CountryService : ICountryService
    {
        private readonly IConfiguration _config;

        public CountryService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CountryResponse> GetCountriesAsync()
        {
            CountryResponse jsonResponse = new CountryResponse();
            try
            {
                var baseUrl = _config.GetSection("airlabsUrl").Value;
                var apiKey = _config.GetSection("API-Keys:AirLabs").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new System.Uri(baseUrl);
                    var response = await httpClient.GetAsync($"api/v9/countries?api_key={apiKey}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        jsonResponse = JsonSerializer.Deserialize<CountryResponse>(json);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }

            return jsonResponse;
        }
    }
}
