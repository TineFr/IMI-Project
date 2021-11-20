using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Imi.Project.Api.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities.Pagination;
using Newtonsoft.Json;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var species = await _speciesService.ListAllSpeciessAsync();
            var paginationData = new PaginationMetaData(parameters.Page, species.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var speciesPaginated = Pagination.AddPagination<Species>(species, parameters);
            var result = speciesPaginated.MapToDtoList();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var species = await _speciesService.GetSpeciesByIdAsync(id);
            if (species == null)
            {
                return NotFound($"Species with id {id} does not exist");
            }
            var result = species.MapToDto();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Post(SpeciesRequestDto newSpecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var species = await _speciesService.GetSpeciesByIdAsync(newSpecies.Id);
            if (species != null)
            {
                return BadRequest($"Species with id {species.Id} already exists");
            }
            var newSpeciesEntity = newSpecies.MapToEntity();
            var result = await _speciesService.AddSpeciesAsync(newSpeciesEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpPut]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Put(SpeciesRequestDto updatedSpecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var species = await _speciesService.GetSpeciesByIdAsync(updatedSpecies.Id);
            if (species == null)
            {
                return NotFound($"Bird with id {updatedSpecies.Id} does not exist");
            }
            species.Update(updatedSpecies);
            var result = await _speciesService.UpdateSpeciesAsync(species);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpDelete]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Delete(SpeciesRequestDto speciesToDelete)
        {
            var species = await _speciesService.GetSpeciesByIdAsync(speciesToDelete.Id);
            if (species == null)
            {
                return NotFound($"Bird with id {speciesToDelete.Id} does not exist");
            }
            await _speciesService.DeleteSpeciesAsync(species);
            return Ok();
        }
    }
}
