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
    public class ComicsController : ControllerBase
    {

        public readonly IApiService ApiService;
        public readonly IConfiguration Configuration;

        public ComicsController(IApiService apiService, IConfiguration configuration)
        {
            ApiService = apiService;
            Configuration = configuration;
        }
        
        [HttpGet("{characterId}")]
        [ActionName("character")]
        public async Task<ActionResult> GetAllComicsByCharacter(long characterId)
        {
            var comics = await ApiService.GetAllComicsByCharacter(characterId);
            comics.Count = comics.Comics.Count();
            return Ok(comics);
        }
        
        [HttpGet("{creatorId}")]
        [ActionName("creator")]
        public async Task<ActionResult> GetAllComicsByCreator(long creatorId)
        {
            var comics = await ApiService.GetAllComicsByCreator(creatorId);
            comics.Count = comics.Comics.Count();
            return Ok(comics);
        }
        
        [HttpGet("{seriesId}")]
        [ActionName("series")]
        public async Task<ActionResult> GetAllComicsBySeries(long seriesId)
        {
            var comics = await ApiService.GetAllComicsBySeries(seriesId);
            comics.Count = comics.Comics.Count();
            return Ok(comics);
        }
    }
}
