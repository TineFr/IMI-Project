using Imi.Project.Api.Core.Interfaces.Services;
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
    public class DailyTasksController : ControllerBase
    {
        protected readonly IDailyTaskService _dailyTaskService;

        public DailyTasksController(IDailyTaskService dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task = await _dailyTaskService.ListAllDailyTasksAsync();
            return Ok(task);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tasks = await _dailyTaskService.GetDailyTaskByIdAsync(id);
            return Ok(tasks);
        }
    }
}
