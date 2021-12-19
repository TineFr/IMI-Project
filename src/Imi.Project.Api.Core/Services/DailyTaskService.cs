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

        public async Task<DailyTask> AddDailyTaskAsync(DailyTask dailyTask)
        {

            var result = await _dailyTaskRepository.AddAsync(dailyTask);
            var dto = result;

            return dto;
        }

        public async Task DeleteDailyTaskAsync(DailyTask dailyTask)
        {


            await _dailyTaskRepository.DeleteAsync(dailyTask);
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

        public async Task<DailyTask> UpdateDailyTaskAsync(DailyTask dailyTask)
        {

            var result = await _dailyTaskRepository.UpdateAsync(dailyTask);
            var dto = result;

            return dto;
        }
    }
}
