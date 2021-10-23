using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Helper;
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
            var cagesDtoList = cages.MaptoDtoList();
            return Ok(cagesDtoList);

        }

    }
}
