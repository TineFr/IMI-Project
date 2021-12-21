using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeController : ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;
        protected readonly IPrescriptionService _prescriptionService;
        protected readonly IMedicineService _medicineService;


        public MeController(IUserService userService, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _userService = userService;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var result = user.MapToDto();
            return Ok(result);
        }


        [HttpGet("cages")]
        public async Task<IActionResult> GetCagesFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var cages = await _cageService.GetCagesByUserIdAsync(userId);
            var paginationData = new PaginationMetaData(parameters.Page, cages.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var cagesPaginated = Pagination.AddPagination<Cage>(cages, parameters);
            var result = cagesPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("birds")]
        public async Task<IActionResult> GetBirdsFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var birds = await _birdService.GetBirdsByUserIdAsync(userId);
            var paginationData = new PaginationMetaData(parameters.Page, birds.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var birdsPaginated = Pagination.AddPagination<Bird>(birds, parameters);
            var result = birdsPaginated.MapToDtoList();
            return Ok(result);
        }
        [HttpGet("medicines")]
        public async Task<IActionResult> GetMedicinesFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var medicines = await _medicineService.GetMedicinesByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, medicines.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var medicinesPaginated = Pagination.AddPagination<Medicine>(medicines, parameters);
            var result = medicinesPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(id);
            var paginationData = new PaginationMetaData(parameters.Page, prescriptions.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var prescriptionsPaginated = Pagination.AddPagination<Prescription>(prescriptions, parameters);
            var result = prescriptionsPaginated.MapToDtoList();
            return Ok(result);
        }

    }
}
