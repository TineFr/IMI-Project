using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    public class BirdsController : Controller
    {
        protected readonly IBirdService _birdService;

        public BirdsController(IBirdService birdService)
        {
            _birdService = birdService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var birds = await _birdService.ListAllBirdsAsync();
            return Ok(birds);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bird = await _birdService.GetBirdByIdAsync(id);
            return Ok(bird);
        }






    }
}   
