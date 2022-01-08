using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Extensions;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        protected readonly IMedicineService _medicineService;


        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<MedicineResponseDto> result;
            try
            {
                result = await _medicineService.ListAllMedicinesAsync(parameters);
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
            MedicineResponseDto result;
            try
            {
                result = await _medicineService.GetMedicineByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicineRequestDto newMedicine)
        {
            if (newMedicine.UserId == null)
            {
                newMedicine.UserId = User.GetUser();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MedicineResponseDto result;
            try
            {
                result = await _medicineService.AddMedicineAsync(newMedicine);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, MedicineRequestDto updatedMedicine)
        {
            if (updatedMedicine.UserId == null)
            {
                updatedMedicine.UserId = User.GetUser();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MedicineResponseDto result;
            try
            {
                result = await _medicineService.UpdateMedicineAsync(id, updatedMedicine);
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
                await _medicineService.DeleteMedicineAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }
    }
}
