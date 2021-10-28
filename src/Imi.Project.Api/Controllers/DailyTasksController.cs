using Imi.Project.Api.Core.Dtos.DailyTasks;
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
            var tasks = await _dailyTaskService.ListAllDailyTasksAsync();
            var result = tasks.MapToDtoList();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           
            var task = await _dailyTaskService.GetDailyTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound($"Daily task with id {id} does not exist");
            }
            var result = task.MapToDto();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DailyTaskRequestDto dailyTaskRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dailyTaskEntity = dailyTaskRequestDto.MapToEntity();
            var result = await _dailyTaskService.AddDailyTaskAsync(dailyTaskEntity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DailyTaskRequestDto dailyTaskRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = await _dailyTaskService.GetDailyTaskByIdAsync(dailyTaskRequestDto.Id);
            if (task == null)
            {
                return NotFound($"Bird with id {dailyTaskRequestDto.Id} does not exist");
            }
            task.Update(dailyTaskRequestDto);
            var result = await _dailyTaskService.UpdateDailyTaskAsync(task);
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = await _dailyTaskService.GetDailyTaskByIdAsync(dailyTaskRequestDto.Id);
            if (task == null)
            {
                return NotFound($"Daily task with id {dailyTaskRequestDto.Id} does not exist");
            }
            await _dailyTaskService.DeleteDailyTaskAsync(task);
            return Ok();
        }
    }
}
