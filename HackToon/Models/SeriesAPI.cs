using HackToon.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models
{
    public class SeriesAPI
    {
        public SeriesApiResponse Series { get; set; }
    }

    public class SeriesResponse
    {
        public int Count { get; set; }
        public List<Series> Series { get; set; }
    }

    public class SeriesPagedResponse : SeriesResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
