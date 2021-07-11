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
        public CharacterApiResponse Characters { get; set; }
    }

    public class CharactersResponse
    {
        public int Count { get; set; }
        public List<Character> Characters { get; set; }
    }

    public class CharactersList
    {
        public int Count { get; set; }
        public List<Pair> Characters { get; set; }

        public CharactersList(List<Character> characters)
        {
            Count = characters.Count();
            Characters = new List<Pair>();
            foreach (var character in characters)
            {
                var characterPair = new Pair
                {
                    Id = character.Id,
                    Name = character.Name
                };
                Characters.Add(characterPair);
            }
        }
    }

    public class CharactersPagedResponse : CharactersResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
