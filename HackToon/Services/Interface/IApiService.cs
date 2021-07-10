using HackToon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Services.Interface
{
    public interface IApiService
    {
        string CalcMD5(string timestamp);
        Task<string> MarvelApiGet(string api, int? limit, int? offset, string ts, string hash); 
        Task<CharactersResponse> GetAllCharacters();
    }
}
