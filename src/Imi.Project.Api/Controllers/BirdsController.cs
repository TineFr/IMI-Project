using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Extensions;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
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
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<BirdResponseDto> paginatedResult;
            try
            {
                var result = await _birdService.ListAllBirdsAsync(parameters);
                var paginationData = new PaginationMetaData(parameters.Page, result.Count(), parameters.ItemsPerPage);
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
                paginatedResult = Pagination.AddPagination<BirdResponseDto>(result, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(paginatedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            BirdResponseDto result;
            try
            {
                result = await _birdService.GetBirdByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BirdRequestDto newBird)
        {
            newBird.UserId = User.GetUser();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BirdResponseDto result;
            try
            {
                result = await _birdService.AddBirdAsync(newBird);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromForm] BirdRequestDto updatedBird)
        {
            updatedBird.UserId = User.GetUser();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BirdResponseDto result;
            try
            {
                result = await _birdService.UpdateBirdAsync(id, updatedBird);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _birdService.DeleteBirdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }

    }
}
