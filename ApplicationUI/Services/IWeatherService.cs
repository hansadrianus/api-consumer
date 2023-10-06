using ApplicationUI.Models.Responses;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetCityWeather(string cityCode);
    }
}