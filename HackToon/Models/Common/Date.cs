using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class Dates
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public object Date { get; set; }
    }
}
