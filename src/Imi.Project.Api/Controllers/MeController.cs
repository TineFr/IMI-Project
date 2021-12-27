﻿using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
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
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<CageResponseDto> result;
            try
            {
                result = await _cageService.GetCagesByUserIdAsync(userId, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("birds")]
        public async Task<IActionResult> GetBirdsFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<BirdResponseDto> result;
            try
            {
                result = await _birdService.GetBirdsByUserIdAsync(userId, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("medicines")]
        public async Task<IActionResult> GetMedicinesFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<MedicineResponseDto> result;
            try
            {
                result = await _medicineService.GetMedicinesByUserIdAsync(userId, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser([FromQuery] PaginationParameters parameters)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<PrescriptionResponseDto> result;
            try
            {
                result = await _prescriptionService.GetPrescriptionsByUserIdAsync(userId, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

    }
}
