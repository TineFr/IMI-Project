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
using System.Security.Claims;
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
        public CagesController(ICageService cageService, 
                               IBirdService birdService, 
                               IDailyTaskService dailyTaskService)
        {
            _cageService = cageService;
            _birdService = birdService;
            _dailyTaskService = dailyTaskService;
        }

        [HttpGet]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<CageResponseDto> paginatedResult;
            try
            {
                var result = await _cageService.ListAllCagesAsync(parameters);
                var paginationData = new PaginationMetaData(parameters.Page, result.Count(), parameters.ItemsPerPage);
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
                paginatedResult = Pagination.AddPagination<CageResponseDto>(result, parameters);
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
            IEnumerable<BirdResponseDto> paginatedResult;
            try
            {
                var result = await _birdService.GetBirdsByUserIdAsync(id, parameters);
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

        [HttpGet("{id}/dailytasks")]
        public async Task<IActionResult> GetDailyTasksByCageId(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<DailyTaskResponseDto> paginatedResult;
            try
            {
                var result = await _dailyTaskService.GetDailyTasksByCageIdAsync(id, parameters);
                var paginationData = new PaginationMetaData(parameters.Page, result.Count(), parameters.ItemsPerPage);
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
                paginatedResult = Pagination.AddPagination<DailyTaskResponseDto>(result, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(paginatedResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CageRequestDto newCage)
        {
            newCage.UserId = User.GetUser();
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
            updatedCage.UserId = User.GetUser();
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

        [HttpDelete("{id}")]
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
