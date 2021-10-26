using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public interface IDailyTaskService
    {
        Task<DailyTask> GetDailyTaskById(Guid id);
        IEnumerable<DailyTask> GetDailyTaskByCageId(Guid id);
        Task<DailyTask> AddDailyTask(DailyTask DailyTask);
        Task<DailyTask> UpdateDailyTask(DailyTask DailyTask);
        Task<DailyTask> DeleteDailyTask(Guid id);
    }
}
