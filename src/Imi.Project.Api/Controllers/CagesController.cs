using Imi.Project.Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class CagesController : ControllerBase
    {
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;
        protected readonly IDailyTaskService _dailyTaskService;


        public CagesController(ICageService cageService, IBirdService birdService, IDailyTaskService dailyTaskService)
        {
            _cageService = cageService;
            _birdService = birdService;
            _dailyTaskService = dailyTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cages = await _cageService.ListAllCagesAsync();
            var result = cages.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var result = cage.MapToDto();
            return Ok(result);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsByCageId(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var birds = await _birdService.GetBirdsByCageIdAsync(id);
            var result = birds.MapToDtoList(); 
            return Ok(result);
        }

        [HttpGet("{id}/dailytasks")]
        public async Task<IActionResult> GetDailyTasksByCageId(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var tasks = await _dailyTaskService.GetDailyTasksByCageIdAsync(id);
            var result = tasks.MapToDtoList();
            return Ok(tasks);
        }
    }
}
