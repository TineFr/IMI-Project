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
    public class MeController : ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;
        protected readonly IPrescriptionService _prescriptionService;
        protected readonly IMedicineService _medicineService;


        public MeController(IUserService userService,
                            ICageService cageService,
                            IBirdService birdService,
                            IMedicineService medicineService,
                            IPrescriptionService prescriptionService)
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
            Guid userId = User.GetUser();
            ApplicationUserResponseDto result;
            try
            {
                result = await _userService.GetUserByIdAsync(userId);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }


        [HttpGet("cages")]
        public async Task<IActionResult> GetCagesFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = User.GetUser();
            IEnumerable<CageResponseDto> paginatedResult;
            try
            {
                var result = await _cageService.GetCagesByUserIdAsync(userId);
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

        [HttpGet("birds")]
        public async Task<IActionResult> GetFilteredBirdsFromUser([FromQuery] PaginationParameters parameters, [FromQuery] Guid speciesId, [FromQuery] Guid cageId)
        {
            Guid userId = User.GetUser();
            IEnumerable<BirdResponseDto> paginatedResult;
            try
            {
                var result = await _birdService.GetBirdsByUserIdAsync(userId);
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



        [HttpGet("medicines")]
        public async Task<IActionResult> GetMedicinesFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = User.GetUser();
            IEnumerable<MedicineResponseDto> paginatedResult;
            try
            {
                var result = await _medicineService.GetMedicinesByUserIdAsync(userId);
                var paginationData = new PaginationMetaData(parameters.Page, result.Count(), parameters.ItemsPerPage);
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
                paginatedResult = Pagination.AddPagination<MedicineResponseDto>(result, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(paginatedResult);
        }

        [HttpGet("prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = User.GetUser();
            IEnumerable<PrescriptionResponseDto> paginatedResult;
            try
            {
                var result = await _prescriptionService.GetPrescriptionsByUserIdAsync(userId);
                var paginationData = new PaginationMetaData(parameters.Page, result.Count(), parameters.ItemsPerPage);
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
                paginatedResult = Pagination.AddPagination<PrescriptionResponseDto>(result, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(paginatedResult);
        }

    }
}
