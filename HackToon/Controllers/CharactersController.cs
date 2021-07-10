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
    }
}
