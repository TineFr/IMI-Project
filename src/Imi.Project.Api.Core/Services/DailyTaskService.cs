using Imi.Project.Api.Core.Dtos.DailyTasks;
using Imi.Project.Api.Core.Entities;
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

        public async Task<DailyTask> AddDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();
            var result = await _dailyTaskRepository.AddAsync(task);
            var dto = result;

            return dto;
        }

        public async Task DeleteDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();

            await _dailyTaskRepository.DeleteAsync(task);
        }

        public async Task<DailyTask> GetDailyTaskByIdAsync(Guid id)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(id);
            return task;
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTasksByCageIdAsync(Guid id)
        {
            var tasks = await _dailyTaskRepository.GetByCageIdAsync(id);
            return tasks;
        }

        public async Task<IEnumerable<DailyTask>> ListAllDailyTasksAsync()
        {
            var tasks = await _dailyTaskRepository.ListAllAsync();
            return tasks;
        }

        public async Task<DailyTask> UpdateDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto)
        {
            var task = dailyTaskRequestDto.MapToEntity();
            var result = await _dailyTaskRepository.UpdateAsync(task);
            var dto = result;

            return dto;
        }
    }
}
