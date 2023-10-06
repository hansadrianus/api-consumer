using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApplicationUI.Models.Responses
{
    public class CountryResponse
    {
        [JsonPropertyName("response")]
        public List<CountryChildResponse> Response { get; set; }
    }

    public class CountryChildResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("code3")]
        public string Code3 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
