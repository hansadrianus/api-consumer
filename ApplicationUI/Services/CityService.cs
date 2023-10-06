using ApplicationUI.Models.Responses;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public class CityService : ICityService
    {
        private readonly IConfiguration _config;

        public CityService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CityResponse> GetCitiesAsync(string countryCode)
        {
            CityResponse jsonResponse = new CityResponse();
            try
            {
                var baseUrl = _config.GetSection("airlabsUrl").Value;
                var apiKey = _config.GetSection("API-Keys:AirLabs").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new System.Uri(baseUrl);
                    var response = await httpClient.GetAsync($"api/v9/cities?country_code={countryCode}&api_key={apiKey}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        jsonResponse = JsonSerializer.Deserialize<CityResponse>(json);
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
