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


        public UsersController(IUserService userService, 
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<ApplicationUserResponseDto> result;
            try
            {
                result = await _userService.ListAllUsersAsync(parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
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
            IEnumerable<CageResponseDto> result;
            try
            {
                result = await _cageService.GetCagesByUserIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<BirdResponseDto> result;
            try
            {
                result = await _birdService.GetBirdsByUserIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }
        [HttpGet("{id}/medicines")]
        public async Task<IActionResult> GetMedicinesFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<MedicineResponseDto> result;
            try
            {
                result = await _medicineService.GetMedicinesByUserIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}/prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser(Guid id, [FromQuery] PaginationParameters parameters)
        {
            IEnumerable<PrescriptionResponseDto> result;
            try
            {
                result = await _prescriptionService.GetPrescriptionsByUserIdAsync(id, parameters);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
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


