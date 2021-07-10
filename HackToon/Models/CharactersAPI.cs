using HackToon.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Models
{
    public class CharactersAPI
    {
        public Characters Characters { get; set; }
    }

    public class CharactersResponse
    {
        public int Count { get; set; }
        public List<Result> Characters { get; set; }
    }

    public class CharactersPagedResponse : CharactersResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; } = 1493;
    }
}
