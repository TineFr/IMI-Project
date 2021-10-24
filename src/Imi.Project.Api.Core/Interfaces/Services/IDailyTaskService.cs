using Imi.Project.Api.Core.Dtos.DailyTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IDailyTaskService
    {
        Task<IEnumerable<DailyTaskResponseDto>> ListAllDailyTasksAsync();
        Task<DailyTaskResponseDto> GetDailyTaskByIdAsync(Guid id);
        Task<DailyTaskResponseDto> AddDailyTaskAsync(DailyTaskRequestDto DailyTaskRequestDto);
        Task<DailyTaskResponseDto> UpdateDailyTaskAsync(DailyTaskRequestDto DailyTaskRequestDto);
        Task DeleteDailyTaskAsync(DailyTaskRequestDto userRequestDto);
        Task<IEnumerable<DailyTaskResponseDto>> GetDailyTasksByCageIdAsync(Guid id);
    }
}
