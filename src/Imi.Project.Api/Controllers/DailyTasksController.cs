
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
    //[Authorize]
    [AllowAnonymous]
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
        public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
        {
            var tasks = await _dailyTaskService.ListAllDailyTasksAsync();
            var paginationData = new PaginationMetaData(parameters.Page, tasks.Count(), parameters.ItemsPerPage);
            Response.Headers.Add("pagination", JsonConvert.SerializeObject(paginationData));
            var tasksPaginated = Pagination.AddPagination<DailyTask>(tasks, parameters);
            var result = tasksPaginated.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            DailyTaskResponseDto result;
            try
            {
                result = await _dailyTaskService.GetDailyTaskByIdAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DailyTaskRequestDto newDailyTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DailyTaskResponseDto result;
            try
            {
                result = await _dailyTaskService.AddDailyTaskAsync(newDailyTask);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, DailyTaskRequestDto updateDailyTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DailyTaskResponseDto result;
            try
            {
                result = await _dailyTaskService.UpdateDailyTaskAsync(id, updateDailyTask);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _dailyTaskService.DeleteDailyTaskAsync(id);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            return Ok();
        }
    }
}
