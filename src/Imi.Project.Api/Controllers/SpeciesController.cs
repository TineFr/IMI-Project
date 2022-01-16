using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<SpeciesResponseDto> result;
            try
            {
                result = await _speciesService.ListAllSpeciessAsync(parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            SpeciesResponseDto result;
            try
            {
                result = await _speciesService.GetSpeciesByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Post([FromForm] SpeciesRequestDto newSpecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SpeciesResponseDto result;
            try
            {
                result = await _speciesService.AddSpeciesAsync(newSpecies);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Put(Guid id, [FromForm] SpeciesRequestDto updatedSpecies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SpeciesResponseDto result;
            try
            {
                result = await _speciesService.UpdateSpeciesAsync(id, updatedSpecies);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _speciesService.DeleteSpeciesAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }
    }
}
