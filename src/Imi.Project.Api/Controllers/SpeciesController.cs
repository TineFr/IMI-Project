using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Imi.Project.Api.Core.Helper;
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
            var result = species.MapToDtoList();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var species = await _speciesService.GetSpeciesByIdAsync(id);
            return Ok(species);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SpeciesRequestDto newspecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var speciesDto = await _speciesService.AddSpeciesAsync(newspecies);
            return Ok(speciesDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SpeciesRequestDto updatedspecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var speciesDto = await _speciesService.UpdateSpeciesAsync(updatedspecies);
            return Ok(speciesDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SpeciesRequestDto updatedspecies)
        {
            if (updatedspecies == null)
            {
                return NotFound($"species does not exist");

            }
            await _speciesService.DeleteSpeciesAsync(updatedspecies);
            return Ok();
        }
    }
}
