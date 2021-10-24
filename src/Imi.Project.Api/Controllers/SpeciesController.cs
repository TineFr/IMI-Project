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
    public class SpeciesController : ControllerBase
    {
        protected readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var species = await _speciesService.ListAllSpeciessAsync();
            return Ok(species);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var species = await _speciesService.GetSpeciesByIdAsync(id);
            return Ok(species);
        }
    }
}
