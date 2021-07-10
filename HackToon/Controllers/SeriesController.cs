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
    public class SeriesController : ControllerBase
    {

        public readonly IApiService ApiService;
        public readonly IConfiguration Configuration;

        public SeriesController(IApiService apiService, IConfiguration configuration)
        {
            ApiService = apiService;
            Configuration = configuration;
        }

        [HttpGet("{characterId}")]
        [ActionName("character")]
        public async Task<ActionResult> GetAllSeriesByCharacter(long characterId)
        {
            var series = await ApiService.GetAllSeriesByCharacter(characterId);
            series.Count = series.Series.Count();
            return Ok(series);
        }

        [HttpGet("{creatorId}")]
        [ActionName("creator")]
        public async Task<ActionResult> GetAllSeriesByCreator(long creatorId)
        {
            var series = await ApiService.GetAllSeriesByCreator(creatorId);
            series.Count = series.Series.Count();
            return Ok(series);
        }

        [HttpGet("{comicId}")]
        [ActionName("comic")]
        public async Task<ActionResult> GetAllSeriesByComic(long comicId)
        {
            var series = await ApiService.GetAllSeriesByComic(comicId);
            series.Count = series.Series.Count();
            return Ok(series);
        }
    }
}
