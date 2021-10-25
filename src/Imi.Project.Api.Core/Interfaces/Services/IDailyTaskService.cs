using Imi.Project.Api.Core.Dtos.DailyTasks;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IDailyTaskService
    {
        Task<IEnumerable<DailyTask>> ListAllDailyTasksAsync();
        Task<DailyTask> GetDailyTaskByIdAsync(Guid id);
        Task<DailyTask> AddDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto);
        Task<DailyTask> UpdateDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto);
        Task DeleteDailyTaskAsync(DailyTaskRequestDto dailyTaskRequestDto);
        Task<IEnumerable<DailyTask>> GetDailyTasksByCageIdAsync(Guid id);
    }
}
