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
        Task<string> GetMarvelList(string api, long? character, long? creator, long? comic, long? series, int? limit, int? offset, string ts, string hash);
        Task<CharactersResponse> GetAllCharacters();
        Task<CharactersPagedResponse> GetPagedCharacters(int pageNumber, int pageSize);
        Task<SeriesResponse> GetAllSeriesByCharacter(long characterId);
        Task<SeriesResponse> GetAllSeriesByCreator(long creatorId);
        Task<SeriesResponse> GetAllSeriesByComic(long comicId);
        Task<ComicsResponse> GetAllComicsByCharacter(long characterId);
        Task<ComicsResponse> GetAllComicsByCreator(long creatorId);
        Task<ComicsResponse> GetAllComicsBySeries(long seriesId);
    }
}
