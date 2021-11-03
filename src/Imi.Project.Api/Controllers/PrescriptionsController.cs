using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Helper;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos.Prescriptions;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Controllers
{
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
        public async Task<IActionResult> Get()
        {
            var prescriptions = await _prescriptionService.ListAllPrescriptionsAsync();
            var result = prescriptions.MapToDtoList();
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
