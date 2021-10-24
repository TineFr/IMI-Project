using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
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

        [HttpGet("/medicines")]
        public async Task<IActionResult> GetBirdsWithMedicine()
        {
            var bird = await _birdService.GetBirdsWithMedicineAsync();
            return Ok(bird);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bird = await _birdService.GetBirdByIdAsync(id);
            return Ok(bird);
        }
    }
}
