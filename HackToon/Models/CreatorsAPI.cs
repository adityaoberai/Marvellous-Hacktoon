using HackToon.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models
{
    public class CreatorsAPI
    {
        public CreatorApiResponse Creators { get; set; }
    }

    public class CreatorsResponse
    {
        public int Count { get; set; }
        public List<Creator> Creators { get; set; }
    }

    public class CreatorsPagedResponse : CreatorsResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
