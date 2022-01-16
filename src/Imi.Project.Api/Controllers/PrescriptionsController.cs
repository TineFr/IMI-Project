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
    [Authorize(Policy = "IsOfAge")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        protected readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        [Authorize(Policy = "AdministratorRole")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            IEnumerable<PrescriptionResponseDto> result;
            try
            {
                result = await _prescriptionService.ListAllPrescriptionsAsync(parameters);
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
            PrescriptionResponseDto result;
            try
            {
                result = await _prescriptionService.GetPrescriptionByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PrescriptionRequestDto newPrescription)
        {
            newPrescription.UserId = User.GetUser();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PrescriptionResponseDto result;
            try
            {
                result = await _prescriptionService.AddPrescriptionAsync(newPrescription);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PrescriptionRequestDto updatedPrescription)
        {
            updatedPrescription.UserId = User.GetUser();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PrescriptionResponseDto result;
            try
            {
                result = await _prescriptionService.UpdatePrescriptionAsync(id, updatedPrescription);
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
                await _prescriptionService.DeletePrescriptionAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }
    }
}
