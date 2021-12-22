using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
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
        protected readonly IUserService _userService;
        protected readonly IImageService _imageService;
        protected readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IUserService userService, IImageService imageService, IPrescriptionService prescriptionService)
        {
            _userService = userService;
            _imageService = imageService;
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
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound($"bird with id {id} does not exist");
            }
            var result = prescription.MapToDto();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PrescriptionRequestDto newPrescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(newPrescription.Id);
            if (prescription != null)
            {
                return BadRequest($"Prescription with id {newPrescription.Id} already exists");
            }
            var user = await _userService.GetUserByIdAsync(newPrescription.UserId);
            if (user == null)
            {
                return NotFound($"User with id {prescription.UserId} does not exist");
            }
            var newPrescripptionEntity = newPrescription.MapToEntity();
            var result = await _prescriptionService.AddPrescriptionAsync(newPrescripptionEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PrescriptionRequestDto updatedPrescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(updatedPrescription.Id);
            if (prescription == null)
            {
                return NotFound($"Prescription with id {updatedPrescription.Id} does not exist");
            }
            var prescriptionEntity = prescription.Update(updatedPrescription);
            var result = await _prescriptionService.UpdatePrescriptionAsync(prescriptionEntity);
            var resultDto = result.MapToDto();
            return Ok(resultDto);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(PrescriptionRequestDto prescriptionToDelete)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(prescriptionToDelete.Id);
            if (prescription == null)
            {
                return NotFound($"Prescription with id {prescription.Id} does not exist");
            }
            await _prescriptionService.DeletePrescriptionAsync(prescription);
            return Ok();
        }




    }
}
