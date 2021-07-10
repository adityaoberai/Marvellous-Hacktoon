using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class Series
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public List<URL> Urls { get; set; }

        [JsonProperty("startYear")]
        public int StartYear { get; set; }

        [JsonProperty("endYear")]
        public int EndYear { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("creators")]
        public Info Creators { get; set; }

        [JsonProperty("characters")]
        public Info Characters { get; set; }

        [JsonProperty("stories")]
        public Info Stories { get; set; }

        [JsonProperty("comics")]
        public Info Comics { get; set; }

        [JsonProperty("events")]
        public Info Events { get; set; }

        [JsonProperty("next")]
        public Move Next { get; set; }

        [JsonProperty("previous")]
        public Move Previous { get; set; }
    }
}
