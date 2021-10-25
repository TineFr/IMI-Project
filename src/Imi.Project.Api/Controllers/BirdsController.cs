using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Helper;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        protected readonly IBirdService _birdService;
        protected readonly ICageService _cageService;
        protected readonly IUserService _userService;
        protected readonly IImageService _imageService;

        public BirdsController(IBirdService birdService, ICageService cageService, IUserService userService, IImageService imageService)
        {
            _birdService = birdService;
            _cageService = cageService;
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var birds = await _birdService.ListAllBirdsAsync();
            var result = birds.MapToDtoList();
            return Ok(result);
        }

        //[HttpGet("{id}/medicines")]
        //public async Task<IActionResult> GetBirdsWithMedicine()
        //{
        //    var Bird = await _BirdService.GetBirdsWithMedicineAsync();
        //    return Ok(Bird);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bird = await _birdService.GetBirdByIdAsync(id);
            if (bird == null)
            {
                return NotFound($"bird with id {id} does not exist");
            }
            return Ok(bird);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BirdRequestDto newBird)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Bird = await _birdService.GetBirdByIdAsync(newBird.Id);
            if (Bird != null)
            {
                return BadRequest($"Bird with id {newBird.Id} already exists");
            }
            var user = await _userService.GetUserByIdAsync(newBird.UserId);
            if (user == null)
            {
                return NotFound($"User with id {newBird.UserId} does not exist");
            }
            var cage = await _cageService.GetCageByIdAsync(newBird.CageId);
            if (user == null)
            {
                return NotFound($"Cage with id {newBird.CageId} does not exist");
            }
            var newBirdEntity = newBird.MapToEntity();
            var result = await _birdService.AddBirdAsync(newBirdEntity);
            return Ok(result.MapToDto());
        }

        [HttpPut]
        public async Task<IActionResult> Put(BirdRequestDto updatedBird)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Bird = await _birdService.GetBirdByIdAsync(updatedBird.Id);
            if (Bird == null)
            {
                return NotFound($"Bird with id {updatedBird.Id} does not exist");
            }
            Bird.Update(updatedBird);
            var result = await _birdService.UpdateBirdAsync(Bird);
            return Ok(result);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(BirdRequestDto BirdToDelete)
        {
            var Bird = await _birdService.GetBirdByIdAsync(BirdToDelete.Id);
            if (Bird == null)
            {
                return NotFound($"Bird with id {BirdToDelete.Id} does not exist");
            }
            await _birdService.DeleteBirdAsync(Bird);
            return Ok();
        }


        [HttpPost("{id}/image"), HttpPut("{id}/image")]


        public async Task<IActionResult> AddOrUpdateImage(Guid id, IFormFile image)
        {
            if (image.ContentType.Contains("image"))
            {
                var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(id, image);
                var album = await _birdService.GetBirdByIdAsync(id);
                if (album == null)
                {
                    return NotFound($"No album with an id of {id} could be found");
                }
                album.Image = databasePath;
                await _birdService.UpdateBirdAsync(album);
                var albumDto = album.MapToDto();
                return Ok(albumDto);
            }
            else return BadRequest("Uploaded file should be an image"); //bad request?     
        }
    }
}
