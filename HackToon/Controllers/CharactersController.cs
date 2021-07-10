using HackToon.Models;
using HackToon.Models.Common;
using HackToon.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HackToon.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        public readonly IApiService ApiService;
        public readonly IConfiguration Configuration;

        public CharactersController(IApiService apiService, IConfiguration configuration)
        {
            ApiService = apiService;
            Configuration = configuration;
        }

        [HttpGet]
        [ActionName("getall")]
        public async Task<ActionResult> GetAllCharacters()
        {
            var characters = await ApiService.GetAllCharacters();
            characters.Count = characters.Characters.Count();
            return Ok(characters);
        }

        [HttpGet]
        [ActionName("get")]
        public async Task<ActionResult> GetCharactersPaged(int pageNumber = 1, int pageSize = 50)
        {
            var characters = await ApiService.GetPagedCharacters(pageNumber, pageSize);
            characters.Count = characters.Characters.Count();
            characters.CurrentPage = pageNumber;
            characters.TotalPages = (1493 / pageSize) + 1;
            return Ok(characters);
        }
    }
}
