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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<CageResponseDto> result;
            try
            {
                result = await _cageService.ListAllCagesAsync(parameters);
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
            CageResponseDto result;
            try
            {
                result = await _cageService.GetCageByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsByCageId(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<BirdResponseDto> result;
            try
            {
                result = await _birdService.GetBirdsByUserIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}/dailytasks")]
        public async Task<IActionResult> GetDailyTasksByCageId(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<DailyTaskResponseDto> result;
            try
            {
                result = await _dailyTaskService.GetDailyTasksByCageIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CageRequestDto newCage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CageResponseDto result;
            try
            {
                result = await _cageService.AddCageAsync(newCage);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,[FromForm] CageRequestDto updatedCage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CageResponseDto result;
            try
            {
                result = await _cageService.UpdateCageAsync(id, updatedCage);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _cageService.DeleteCageAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }


    }
}
