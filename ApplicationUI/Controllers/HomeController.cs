using ApplicationUI.Models;
using ApplicationUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IWeatherService _weatherService;

        public HomeController(ILogger<HomeController> logger, ICountryService countryService, ICityService cityService, IWeatherService weatherService)
        {
            _logger = logger;
            _countryService = countryService;
            _cityService = cityService;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
            =>Ok(await _countryService.GetCountriesAsync());

        [HttpGet("GetCitiesFromCountry")]
        public async Task<IActionResult> GetCitiesFromCountry(string countryCode)
            => Ok(await _cityService.GetCitiesAsync(countryCode));

        [HttpGet("GetCityWeather")]
        public async Task<IActionResult> GetCityWeather(string city)
            => Ok(await _weatherService.GetCityWeather(city));
    }
}
