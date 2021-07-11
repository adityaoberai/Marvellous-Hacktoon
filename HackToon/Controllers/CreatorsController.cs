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
    public class CreatorsController : ControllerBase
    {

        public readonly IApiService ApiService;
        public readonly IConfiguration Configuration;

        public CreatorsController(IApiService apiService, IConfiguration configuration)
        {
            ApiService = apiService;
            Configuration = configuration;
        }

        [HttpGet]
        [ActionName("all")]
        public async Task<ActionResult> GetAllCreators()
        {
            var creators = await ApiService.GetAllCreators();
            creators.Count = creators.Creators.Count();
            return Ok(creators);
        }

        [HttpGet]
        [ActionName("list")]
        public async Task<ActionResult> GetAllCreatorsList()
        {
            var creators = await ApiService.GetAllCreators();
            var creatorsList = new CreatorsList(creators.Creators);
            return Ok(creatorsList);
        }

        [HttpGet]
        [ActionName("paged")]
        public async Task<ActionResult> GetPagedCreators(int pageNumber = 1, int pageSize = 50)
        {
            var creators = await ApiService.GetPagedCreators(pageNumber, pageSize);
            creators.Count = creators.Creators.Count();
            creators.CurrentPage = pageNumber;
            creators.TotalPages = (5551 / pageSize) + 1;
            return Ok(creators);
        }
    }
}
