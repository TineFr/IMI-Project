using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Helper;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos.Medicines;
using Imi.Project.Api.Core.Entities.Pagination;
using Newtonsoft.Json;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        protected readonly IMedicineService _medicineService;
        protected readonly IUserService _userService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var medicines = await _medicineService.ListAllMedicinesAsync();
            var paginationData = new PaginationMetaData(parameters.Page, medicines.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var medicinesPaginated = Pagination.AddPagination<Medicine>(medicines, parameters);
            var result = medicinesPaginated.MapToDtoList();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(id);
            if (medicine == null)
            {
                return NotFound($"Medicine with id {id} does not exist");
            }
            var result = medicine.MapToDto();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(MedicineRequestDto medicineRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicine = await _medicineService.GetMedicineByIdAsync(medicineRequestDto.Id);
            if (medicine != null)
            {
                return BadRequest($"Medicine with id {medicineRequestDto.Id} already exists");
            }
            var user = await _userService.GetUserByIdAsync(medicineRequestDto.UserId);
            if (user == null)
            {
                return NotFound($"User with id {medicineRequestDto.UserId} does not exist");
            }
            var medicineRequestDtoEntity = medicineRequestDto.MapToEntity();
            var result = await _medicineService.AddMedicineAsync(medicineRequestDtoEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MedicineRequestDto medicineRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicine = await _medicineService.GetMedicineByIdAsync(medicineRequestDto.Id);
            if (medicine == null)
            {
                return NotFound($"Medicine with id {medicineRequestDto.Id} does not exist");
            }
            medicine.Update(medicineRequestDto);
            var result = await _medicineService.UpdateMedicineAsync(medicine);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(MedicineRequestDto medicineRequestDto)
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(medicineRequestDto.Id);
            if (medicine == null)
            {
                return NotFound($"Medicine with id {medicineRequestDto.Id} does not exist");
            }
            await _medicineService.DeleteMedicineAsync(medicine);
            return Ok();
        }
    }
}
