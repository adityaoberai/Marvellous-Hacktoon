using HackToon.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models
{
    public class ComicsAPI
    {
        public ComicsApiResponse Comics { get; set; }
    }

    public class ComicsResponse
    {
        public int Count { get; set; }
        public List<Comic> Comics { get; set; }
    }

    public class ComicsPagedResponse : ComicsResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
