using Imi.Project.Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class CagesController : ControllerBase
    {
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;


        public CagesController(ICageService cageService , IBirdService birdService)
        {
            _cageService = cageService;
            _birdService = birdService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cages = await _cageService.ListAllCagesAsync();
            return Ok(cages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            return Ok(cage);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsByCageId(Guid id)
        {
            var birds = await _birdService.GetBirdsByCageIdAsync(id);
            return Ok(birds);
        }



    }
}
