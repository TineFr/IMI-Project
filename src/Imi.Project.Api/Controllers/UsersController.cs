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
    public class UsersController : ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;
        protected readonly IPrescriptionService _prescriptionService;
        protected readonly IMedicineService _medicineService;


        public UsersController(IUserService userService, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _userService = userService;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var users = await _userService.ListAllUsersAsync();
            var paginationData = new PaginationMetaData(parameters.Page, users.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var usersPaginated = Pagination.AddPagination<ApplicationUser>(users, parameters);
            var result = usersPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            ApplicationUserResponseDto result;
            try
            {
                result = await _userService.GetUserByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}/cages")]
        public async Task<IActionResult> GetCagesFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var cages = await _cageService.GetCagesByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, cages.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var cagesPaginated = Pagination.AddPagination<Cage>(cages, parameters);
            var result = cagesPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var birds = await _birdService.GetBirdsByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, birds.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var birdsPaginated = Pagination.AddPagination<Bird>(birds, parameters);
            var result = birdsPaginated.MapToDtoList();
            return Ok(result);
        }
        [HttpGet("{id}/medicines")]
        public async Task<IActionResult> GetMedicinesFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var medicines = await _medicineService.GetMedicinesByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, medicines.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var medicinesPaginated = Pagination.AddPagination<Medicine>(medicines, parameters);
            var result = medicinesPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}/prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, prescriptions.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var prescriptionsPaginated = Pagination.AddPagination<Prescription>(prescriptions, parameters);
            var result = prescriptionsPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ApplicationUserRequestDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUserResponseDto result;
            try
            {
                result = await _userService.AddUserAsync(newUser);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ApplicationUserRequestDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUserResponseDto result;
            try
            {
                result = await _userService.UpdateUserAsync(id, updatedUser);
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
                await _userService.DeleteUserAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }


    }

}


