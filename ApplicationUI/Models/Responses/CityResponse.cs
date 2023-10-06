using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApplicationUI.Models.Responses
{
    public class CityResponse
    {
        [JsonPropertyName("response")]
        public List<CityChildResponse> Response { get; set; }
    }

    public class CityChildResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
