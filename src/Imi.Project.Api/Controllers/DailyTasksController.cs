using Imi.Project.Api.Core.Dtos.DailyTasks;
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

        [HttpPost]
        public async Task<IActionResult> Post(DailyTaskRequestDto dailyTaskRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var taskDto = await _dailyTaskService.AddDailyTaskAsync(dailyTaskRequestDto);
            return Ok(taskDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DailyTaskRequestDto dailyTaskRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var taskDto = await _dailyTaskService.UpdateDailyTaskAsync(dailyTaskRequestDto);
            return Ok(taskDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DailyTaskRequestDto dailyTaskRequestDto)
        {
            if (dailyTaskRequestDto == null)
            {
                return NotFound($"species does not exist");

            }
            await _dailyTaskService.DeleteDailyTaskAsync(dailyTaskRequestDto);
            return Ok();
        }
    }
}
