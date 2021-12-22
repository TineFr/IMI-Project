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
            //string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
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

        //[HttpPut]
        //public async Task<IActionResult> Put([FromForm] BirdRequestDto updatedBird)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var bird = await _birdService.GetBirdByIdAsync(updatedBird.Id);
        //    if (bird == null)
        //    {
        //        return NotFound($"Bird with id {updatedBird.Id} does not exist");
        //    }
        //    var updatedBirdEntity = bird.Update(updatedBird);

        //    if (updatedBird.Image != null)
        //    {
        //        if (updatedBird.Image.ContentType.Contains("image"))
        //        {
        //            var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(updatedBird.Id, updatedBird.Image);
        //            updatedBirdEntity.Image = databasePath;
        //        }
        //        else return BadRequest("Uploaded file should be an image");
        //    }

        //    var result = await _birdService.UpdateBirdAsync(bird);
        //    var resultDto = result.MapToDto();
        //    return Ok(resultDto);
        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete(BirdRequestDto birdToDelete)
        //{
        //    var bird = await _birdService.GetBirdByIdAsync(birdToDelete.Id);
        //    if (bird == null)
        //    {
        //        return NotFound($"Bird with id {birdToDelete.Id} does not exist");
        //    }
        //    await _birdService.DeleteBirdAsync(bird);
        //    return Ok();
        //}

    }
}
