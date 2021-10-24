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

        public Task<DailyTaskResponseDto> AddDailyTaskAsync(DailyTaskRequestDto DailyTaskRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDailyTaskAsync(DailyTaskRequestDto userRequestDto)
        {
            throw new NotImplementedException();
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

        public Task<DailyTaskResponseDto> UpdateDailyTaskAsync(DailyTaskRequestDto DailyTaskRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
