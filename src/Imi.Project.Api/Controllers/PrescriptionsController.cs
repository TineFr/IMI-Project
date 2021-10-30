using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Helper;
using System.Threading.Tasks;

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
            prescription.MapToDto();
            return Ok(prescription);
        }

    }
}
