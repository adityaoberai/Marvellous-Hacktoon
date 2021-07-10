using HackToon.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class ApiResponse
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHTML { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }
    }

    public class CharacterApiResponse : ApiResponse
    {
        [JsonProperty("data")]
        public CharacterData Data { get; set; }
    }

    public class SeriesApiResponse : ApiResponse
    {
        [JsonProperty("data")]
        public SeriesData Data { get; set; }
    }
}
