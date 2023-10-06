using ApplicationUI.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationUI.Services
{
    public interface ICountryService
    {
        Task<CountryResponse> GetCountriesAsync();
    }
}