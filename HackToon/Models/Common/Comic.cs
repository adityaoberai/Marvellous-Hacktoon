using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models.Common
{
    public class Comic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("issueNumber")]
        public decimal IssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public object Modified { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }

        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("issn")]
        public string Issn { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("textObjects")]
        public List<TextObject> TextObjects { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public List<URL> Urls { get; set; }

        [JsonProperty("series")]
        public Item Series { get; set; }

        [JsonProperty("variants")]
        public List<Item> Variants { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("collectedIssues")]
        public List<object> CollectedIssues { get; set; }

        [JsonProperty("dates")]
        public List<Dates> Dates { get; set; }

        [JsonProperty("prices")]
        public List<Pricing> Prices { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("creators")]
        public Info Creators { get; set; }

        [JsonProperty("characters")]
        public Info Characters { get; set; }

        [JsonProperty("stories")]
        public Info Stories { get; set; }

        [JsonProperty("events")]
        public Info Events { get; set; }
    }
}
