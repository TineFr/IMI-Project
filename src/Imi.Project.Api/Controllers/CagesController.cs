using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
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
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"cage with id {id} does not exist");
            }
            var result = cage.MapToDto();
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
            var cage = await _cageService.GetCageByIdAsync(newCage.Id);
            if (cage != null)
            {
                return BadRequest($"cage with id {newCage.Id} already exists");
            }
            var user = await _userService.GetUserByIdAsync(newCage.UserId);
            if (user == null)
            {
                return NotFound($"User with id {newCage.UserId} does not exist");
            }
            var newCageEntity = newCage.MapToEntity();

            if (newCage.Image != null)
            {
                if (newCage.Image.ContentType.Contains("image"))
                {
                    var databasePath = await _imageService.AddOrUpdateImageAsync<Cage>(newCage.Id, newCage.Image);
                    newCageEntity.Image = databasePath;
                }
                else return BadRequest("Uploaded file should be an image");
            }

            var result = await _cageService.AddCageAsync(newCageEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] CageRequestDto updatedCage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cage = await _cageService.GetCageByIdAsync(updatedCage.Id);
            if (cage == null)
            {
                return NotFound($"cage with id {updatedCage.Id} does not exist");
            }
            var updatedCageEntity = cage.Update(updatedCage);
            if (updatedCage.Image != null)
            {
                if (updatedCage.Image.ContentType.Contains("image"))
                {
                    var databasePath = await _imageService.AddOrUpdateImageAsync<Cage>(updatedCage.Id, updatedCage.Image);
                    updatedCageEntity.Image = databasePath;
                }
                else return BadRequest("Uploaded file should be an image");
            }
            var result = await _cageService.UpdateCageAsync(updatedCageEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(CageRequestDto cageToDelete)
        {
            var cage = await _cageService.GetCageByIdAsync(cageToDelete.Id);
            if (cage == null)
            {
                return NotFound($"cage with id {cageToDelete.Id} does not exist");
            }
            await _cageService.DeleteCageAsync(cage);
            return Ok();
        }


    }
}
