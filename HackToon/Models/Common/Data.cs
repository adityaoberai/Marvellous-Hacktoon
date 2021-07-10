using HackToon.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Response
{
    public class Data
    {
        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }
    }

    public class CharacterData : Data
    {
        [JsonProperty("results")]
        public List<Character> Results { get; set; }
    }

    public class SeriesData : Data
    {
        [JsonProperty("results")]
        public List<Series> Results { get; set; }
    }
}
