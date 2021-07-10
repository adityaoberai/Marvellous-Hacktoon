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
}
