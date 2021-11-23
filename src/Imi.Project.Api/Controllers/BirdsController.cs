
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Helper;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Imi.Project.Common.Dtos.Birds;

namespace Imi.Project.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        protected readonly IBirdService _birdService;
        protected readonly ICageService _cageService;
        protected readonly IMedicineService _medicineService;
        protected readonly IUserService _userService;
        protected readonly IImageService _imageService;

        public BirdsController(IBirdService birdService, ICageService cageService, IUserService userService, IImageService imageService, IMedicineService medicineService)
        {
            _birdService = birdService;
            _cageService = cageService;
            _userService = userService;
            _imageService = imageService;
            _medicineService = medicineService;
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
            var bird = await _birdService.GetBirdByIdAsync(id);
            if (bird == null)
            {
                return NotFound($"bird with id {id} does not exist");
            }
            var result = bird.MapToDto();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BirdRequestDto newBird)
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
            if (cage == null)
            {
                return NotFound($"Cage with id {newBird.CageId} does not exist");
            }
            var newBirdEntity = newBird.MapToEntity();

            if (newBird.Image != null)
            {
                if (newBird.Image.ContentType.Contains("image"))
                {
                    var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(newBird.Id, newBird.Image);
                    newBirdEntity.Image = databasePath;
                }
                else return BadRequest("Uploaded file should be an image");
            }
            var result = await _birdService.AddBirdAsync(newBirdEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm]  BirdRequestDto updatedBird)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bird = await _birdService.GetBirdByIdAsync(updatedBird.Id);
            if (bird == null)
            {
                return NotFound($"Bird with id {updatedBird.Id} does not exist");
            }
            var updatedBirdEntity =  bird.Update(updatedBird);

            if (updatedBird.Image != null)
            {
                if (updatedBird.Image.ContentType.Contains("image"))
                {
                    var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(updatedBird.Id, updatedBird.Image);
                    updatedBirdEntity.Image = databasePath;
                }
                else return BadRequest("Uploaded file should be an image");
            }

            var result = await _birdService.UpdateBirdAsync(bird);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(BirdRequestDto birdToDelete)
        {
            var bird = await _birdService.GetBirdByIdAsync(birdToDelete.Id);
            if (bird == null)
            {
                return NotFound($"Bird with id {birdToDelete.Id} does not exist");
            }
            await _birdService.DeleteBirdAsync(bird);
            return Ok();
        }

    }
}
