using HackToon.Models;
using HackToon.Models.Common;
using HackToon.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HackToon.Services.Implementation
{
    public class ApiService : IApiService
    {
        public readonly IConfiguration Configuration;

        public ApiService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetTimestamp()
        {
            var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var epochDiff = DateTime.UtcNow - epochDate;
            return Math.Ceiling(epochDiff.TotalMilliseconds).ToString();
        }

        public string CalcMD5(string timestamp)
        {
            string ts = timestamp;
            string input = ts + Configuration["API:PrivateKey"] + Configuration["API:PublicKey"];

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2").ToLower());
            }
            return sb.ToString();
        }

        public async Task<string> GetMarvelCharacters(int? limit, int? offset, string ts, string hash)
        {
            string apikey = Configuration["API:PublicKey"];
            string url = $"https://gateway.marvel.com:443/v1/public/characters?ts={ts}&apikey={apikey}&hash={hash}&limit={limit}&offset={offset}";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetMarvelSeries(long? character, long? creator, long? comic, int? limit, int? offset, string ts, string hash)
        {
            string apikey = Configuration["API:PublicKey"];
            string url = $"https://gateway.marvel.com:443/v1/public/series?ts={ts}&apikey={apikey}&hash={hash}&limit={limit}&offset={offset}";
            if(character != null)
            {
                url += $"&characters={character}";
            }
            if (creator != null)
            {
                url += $"&creators={creator}";
            }
            if (comic != null)
            {
                url += $"&comics={comic}";
            }
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<CharactersResponse> GetAllCharacters()
        {
            var timestamp = GetTimestamp();
            var md5 = CalcMD5(timestamp);

            var charactersResponse = new CharactersResponse
            {
                Characters = new List<Character>()
            };

            var limit = 100;
            var offset = 0;

            do
            {
                var json = await GetMarvelCharacters(limit, offset, timestamp, md5);
                var characters = new CharactersAPI
                {
                    Characters = JsonConvert.DeserializeObject<CharacterApiResponse>(json)
                };
                offset += limit;
                charactersResponse.Characters.AddRange(characters.Characters.Data.Results.AsEnumerable());
            }
            while (offset <= 1400);
            return charactersResponse;
        }

        public async Task<CharactersPagedResponse> GetPagedCharacters(int pageNumber, int pageSize)
        {
            var timestamp = GetTimestamp();
            var md5 = CalcMD5(timestamp);

            var charactersResponse = new CharactersPagedResponse
            {
                Characters = new List<Character>()
            };

            var limit = pageSize;
            var offset = (pageNumber-1) * pageSize;
            
            var json = await GetMarvelCharacters(limit, offset, timestamp, md5);
            var characters = new CharactersAPI
            {
                Characters = JsonConvert.DeserializeObject<CharacterApiResponse>(json)
            };
            offset += limit;
            charactersResponse.Characters.AddRange(characters.Characters.Data.Results.AsEnumerable());

            return charactersResponse;
        }

        public async Task<SeriesResponse> GetAllSeriesByCharacter(long characterId)
        {
            var timestamp = GetTimestamp();
            var md5 = CalcMD5(timestamp);

            var seriesResponse = new SeriesResponse
            {
                Series = new List<Series>()
            };

            var limit = 100;
            var offset = 0;

            var json = "";

            do
            {
                json = await GetMarvelSeries(characterId, null, null, limit, offset, timestamp, md5);
                var series = new SeriesAPI
                {
                    Series = JsonConvert.DeserializeObject<SeriesApiResponse>(json)
                };
                offset += limit;
                if(series.Series.Data.Count == 0)
                {
                    break;
                }
                else
                {
                    seriesResponse.Series.AddRange(series.Series.Data.Results.AsEnumerable());
                }
            }
            while (true);
            
            return seriesResponse;
        }

        public async Task<SeriesResponse> GetAllSeriesByCreator(long creatorId)
        {
            var timestamp = GetTimestamp();
            var md5 = CalcMD5(timestamp);

            var seriesResponse = new SeriesResponse
            {
                Series = new List<Series>()
            };

            var limit = 100;
            var offset = 0;

            var json = "";

            do
            {
                json = await GetMarvelSeries(null, creatorId, null, limit, offset, timestamp, md5);
                var series = new SeriesAPI
                {
                    Series = JsonConvert.DeserializeObject<SeriesApiResponse>(json)
                };
                offset += limit;
                if (series.Series.Data.Count == 0)
                {
                    break;
                }
                else
                {
                    seriesResponse.Series.AddRange(series.Series.Data.Results.AsEnumerable());
                }
            }
            while (true);

            return seriesResponse;
        }

        public async Task<SeriesResponse> GetAllSeriesByComic(long comicId)
        {
            var timestamp = GetTimestamp();
            var md5 = CalcMD5(timestamp);

            var seriesResponse = new SeriesResponse
            {
                Series = new List<Series>()
            };

            var limit = 100;
            var offset = 0;

            var json = "";

            do
            {
                json = await GetMarvelSeries(null, null, comicId, limit, offset, timestamp, md5);
                var series = new SeriesAPI
                {
                    Series = JsonConvert.DeserializeObject<SeriesApiResponse>(json)
                };
                offset += limit;
                if (series.Series.Data.Count == 0)
                {
                    break;
                }
                else
                {
                    seriesResponse.Series.AddRange(series.Series.Data.Results.AsEnumerable());
                }
            }
            while (true);

            return seriesResponse;
        }
    }
}
