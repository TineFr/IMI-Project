using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Mocking.Services
{
    public class MockDailyTaskService : IDailyTaskService
    {
        private static readonly ObservableCollection<DailyTask> dailyTaskrepository = new ObservableCollection<DailyTask>
        {
                    new DailyTask
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Refill water",
                    CageId = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    IsDone = false


                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("5E94B39A-58B3-4719-9595-1440681C53A6"),
                    Name = "Clean branches",
                    CageId = Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949"),
                    IsDone = false
                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("5F15E9F6-FCBE-4FB7-A15B-5E59E9613238"),
                    Name = "Clean branches",
                    CageId =  Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    IsDone = true
                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("EA29EC6D-918D-4590-A409-D332B06E7133"),
                    Name = "Refill water",
                    CageId =   Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949"),
                    IsDone = true
                    },


        };

        public Task<DailyTask> AddDailyTask(DailyTask DailyTask)
        {
            dailyTaskrepository.Add(DailyTask);
            return Task.FromResult(DailyTask);
        }

        public Task<DailyTask> DeleteDailyTask(Guid id)
        {
            var DailyTask = dailyTaskrepository.FirstOrDefault(b => b.Id.Equals(id));
            dailyTaskrepository.Remove(DailyTask);
            return Task.FromResult(DailyTask);
        }


        public Task<List<DailyTask>> GetDailyTaskByCageId(Guid id)
        {
            var DailyTasks = dailyTaskrepository.Where(b => b.CageId.Equals(id)).ToList();
            return Task.FromResult(DailyTasks);
        }


        public Task<DailyTask> GetDailyTaskById(Guid id)
        {
            var DailyTask = dailyTaskrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(DailyTask);
        }

        public Task<DailyTask> UpdateDailyTask(DailyTask updatedDailyTask)
        {
            var DailyTask = dailyTaskrepository.FirstOrDefault(b => b.Id.Equals(updatedDailyTask.Id));
            dailyTaskrepository.ToList().Remove(DailyTask);
            dailyTaskrepository.ToList().Add(updatedDailyTask);
            return Task.FromResult(updatedDailyTask);
        }

    }
}
