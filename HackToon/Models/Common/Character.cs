using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class Character
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("comics")]
        public Info Comics { get; set; }

        [JsonProperty("series")]
        public Info Series { get; set; }

        [JsonProperty("stories")]
        public Info Stories { get; set; }

        [JsonProperty("events")]
        public Info Events { get; set; }

        [JsonProperty("urls")]
        public List<URL> Urls { get; set; }
    }
}
