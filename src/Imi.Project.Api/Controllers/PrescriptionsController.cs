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
    [Authorize]
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var prescriptions = await _prescriptionService.ListAllPrescriptionsAsync();
            var paginationData = new PaginationMetaData(parameters.Page, prescriptions.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var prescriptionsPaginated = Pagination.AddPagination<Prescription>(prescriptions, parameters);
            var result = prescriptionsPaginated.MapToDtoList();
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
