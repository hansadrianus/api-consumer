using ApplicationUI.Models.Responses;
using ApplicationUI.Utilities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _config;

        public WeatherService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<WeatherResponse> GetCityWeather(string city)
        {
            WeatherResponse jsonResponse = new WeatherResponse();
            try
            {
                var baseUrl = _config.GetSection("openWeatherUrl").Value;
                var apiKey = _config.GetSection("API-Keys:OpenWeather").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new System.Uri(baseUrl);
                    var response = await httpClient.GetAsync($"/data/2.5/weather?q={city}&appid={apiKey}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        jsonResponse = JsonSerializer.Deserialize<WeatherResponse>(json);
                        jsonResponse.Main.TempCelc = TemperatureUtility.ConvertTemperatureToCelcius(jsonResponse.Main.Temp);
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
