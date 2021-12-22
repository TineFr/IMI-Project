using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    //[Authorize]
    [AllowAnonymous]
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var birds = await _birdService.ListAllBirdsAsync();
            var paginationData = new PaginationMetaData(parameters.Page, birds.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var birdsPaginated = Pagination.AddPagination<Bird>(birds, parameters);
            var result = birdsPaginated.MapToDtoList();
            return Ok(result);
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

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] BirdRequestDto updatedBird)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BirdResponseDto result;
            try
            {
                result = await _birdService.UpdateBirdAsync(updatedBird);
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
