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

    public class CreatorsList
    {
        public int Count { get; set; }
        public List<Pair> Creators { get; set; }

        public CreatorsList(List<Creator> creators)
        {
            Count = creators.Count();
            Creators = new List<Pair>();
            foreach (var creator in creators)
            {
                var creatorPair = new Pair
                {
                    Id = creator.Id,
                    Name = creator.FullName
                };
                Creators.Add(creatorPair);
            }
        }
    }
    public class CreatorsPagedResponse : CreatorsResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
