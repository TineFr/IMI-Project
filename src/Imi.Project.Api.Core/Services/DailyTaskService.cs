using Imi.Project.Api.Core.Dtos.DailyTasks;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        protected readonly IDailyTaskRepository _dailyTaskRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
        }

        public async Task<DailyTaskResponseDto> AddDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();
            var result = await _dailyTaskRepository.AddAsync(task);
            var dto = result.MapToDto();

            return dto;
        }

        public async Task DeleteDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();

            await _dailyTaskRepository.DeleteAsync(task);
        }

        public async Task<DailyTaskResponseDto> GetDailyTaskByIdAsync(Guid id)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(id);
            return task.MapToDto();
        }

        public async Task<IEnumerable<DailyTaskResponseDto>> GetDailyTasksByCageIdAsync(Guid id)
        {
            var tasks = await _dailyTaskRepository.GetByCageIdAsync(id);
            return tasks.MapToDtoList();
        }

        public async Task<IEnumerable<DailyTaskResponseDto>> ListAllDailyTasksAsync()
        {
            var tasks = await _dailyTaskRepository.ListAllAsync();
            return tasks.MapToDtoList();
        }

        public async Task<DailyTaskResponseDto> UpdateDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();
            var result = await _dailyTaskRepository.UpdateAsync(task);
            var dto = result.MapToDto();

            return dto;
        }
    }
}
