using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CagesController : ControllerBase
    {
        protected readonly ICageService _cageService;
        protected readonly IUserService _userService;
        protected readonly IBirdService _birdService;
        protected readonly IDailyTaskService _dailyTaskService;
        protected readonly IImageService _imageService;



        public CagesController(ICageService cageService, IBirdService birdService, IDailyTaskService dailyTaskService, IUserService userService, IImageService imageService)
        {
            _cageService = cageService;
            _birdService = birdService;
            _dailyTaskService = dailyTaskService;
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var cages = await _cageService.ListAllCagesAsync();
            var paginationData = new PaginationMetaData(parameters.Page, cages.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var cagesPaginated = Pagination.AddPagination<Cage>(cages, parameters);
            var result = cagesPaginated.MapToDtoList();
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
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"cage with id {id} does not exist");
            }
            var birds = await _birdService.GetBirdsByCageIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, birds.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var birdsPaginated = Pagination.AddPagination<Bird>(birds, parameters);
            var result = birdsPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}/dailytasks")]
        public async Task<IActionResult> GetDailyTasksByCageId(Guid id, [FromQuery] PaginationParameters parameters)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"cage with id {id} does not exist");
            }
            var tasks = await _dailyTaskService.GetDailyTasksByCageIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, tasks.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var tasksPaginated = Pagination.AddPagination<DailyTask>(tasks, parameters);
            var result = tasksPaginated.MapToDtoList();
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
