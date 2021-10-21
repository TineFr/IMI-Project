using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class CagesController : ControllerBase
    {
        protected readonly ICageRepository _cageRepository;

        public CagesController(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cages = await _cageRepository.ListAllAsync();
            var cagesDto = cages.Select(c =>
            new CageResponseDto
            {
                Id = c.Id,
                Image = c.Image,
                Name = c.Name,
                Location = c.Location,
                Birds = c.Birds.Select(b =>
                new BirdResponseDto
                {
                    Id = b.Id,
                    

                }).ToList(),
                DailyTasks = c.DailyTasks.Select(b =>
                new DailyTaskResponseDto
                {
                    Id = b.Id,


                }).ToList(),
            });

            return Ok(cagesDto);

        }

    }
}
