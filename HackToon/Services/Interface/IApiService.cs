using HackToon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackToon.Services.Interface
{
    public interface IApiService
    {
        string GetTimestamp();
        string CalcMD5(string timestamp);
        Task<string> GetMarvelCharacters(int? limit, int? offset, string ts, string hash);
        Task<string> GetMarvelSeries(long? character, long? creator, long? comic, int? limit, int? offset, string ts, string hash);
        Task<CharactersResponse> GetAllCharacters();
        Task<CharactersPagedResponse> GetPagedCharacters(int pageNumber, int pageSize);
        Task<SeriesResponse> GetAllSeriesByCharacter(long characterId);
        Task<SeriesResponse> GetAllSeriesByCreator(long creatorId);
        Task<SeriesResponse> GetAllSeriesByComic(long comicId);
    }
}
