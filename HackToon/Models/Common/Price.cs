using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class Pricing
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
