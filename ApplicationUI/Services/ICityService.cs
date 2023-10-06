using ApplicationUI.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public interface ICityService
    {
        Task<CityResponse> GetCitiesAsync(string countryCode);
    }
}