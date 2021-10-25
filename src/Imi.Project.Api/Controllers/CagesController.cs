using Imi.Project.Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Dtos.Cages;
using Imi.Project.Api.Core.Entities;

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
        public async Task<IActionResult> Get()
        {
            var cages = await _cageService.ListAllCagesAsync();
            var result = cages.MapToDtoList();
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
        public async Task<IActionResult> GetBirdsByCageId(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"cage with id {id} does not exist");
            }
            var birds = await _birdService.GetBirdsByCageIdAsync(id);
            var result = birds.MapToDtoList(); 
            return Ok(result);
        }

        [HttpGet("{id}/dailytasks")]
        public async Task<IActionResult> GetDailyTasksByCageId(Guid id)
        {
            var cage = await _cageService.GetCageByIdAsync(id);
            if (cage == null)
            {
                return NotFound($"cage with id {id} does not exist");
            }
            var tasks = await _dailyTaskService.GetDailyTasksByCageIdAsync(id);
            var result = tasks.MapToDtoList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CageRequestDto newCage)
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
            var result = await _cageService.AddCageAsync(newCageEntity);
            return Ok(result.MapToDto());
        }

        [HttpPut]
        public async Task<IActionResult> Put(CageRequestDto updatedCage)
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
            cage.Update(updatedCage);
            var result = await _cageService.UpdateCageAsync(cage);
            return Ok(result);
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


        [HttpPost("{id}/image"), HttpPut("{id}/image")]

        public async Task<IActionResult> AddOrUpdateImage(Guid id, IFormFile image)
        {
            if (image.ContentType.Contains("image"))
            {
                var databasePath = await _imageService.AddOrUpdateImageAsync<Cage>(id, image);
                var album = await _cageService.GetCageByIdAsync(id);
                if (album == null)
                {
                    return NotFound($"No album with an id of {id} could be found");
                }
                album.Image = databasePath;
                await _cageService.UpdateCageAsync(album);
                var albumDto = album.MapToDto();
                return Ok(albumDto);
            }
            else return BadRequest("Uploaded file should be an image"); //bad request?     
        }


    }
}
