using Imi.Project.Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Interfaces.Repositories;

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



    }
}
