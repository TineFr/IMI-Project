using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking.Services
{
    class MockDailyTaskService : IDailyTaskService
    {
        private static ObservableCollection<DailyTask> DailyTaskrepository = new ObservableCollection<DailyTask>
        {
                    new DailyTask
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Refill water",
                    CageId = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E")

                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Clean branches",
                    CageId = Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949")

                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Refill water",
                    CageId =  Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E")

                    },
                    new DailyTask
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Refill water",
                    CageId =   Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949")

                    },


        };

        public Task<DailyTask> AddDailyTask(DailyTask DailyTask)
        {
            DailyTaskrepository.Add(DailyTask);
            return Task.FromResult(DailyTask);
        }

        public Task<DailyTask> DeleteDailyTask(Guid id)
        {
            var DailyTask = DailyTaskrepository.FirstOrDefault(b => b.Id.Equals(id));
            DailyTaskrepository.Remove(DailyTask);
            return Task.FromResult(DailyTask);
        }

        public IEnumerable<DailyTask> GetDailyTaskByCageId(Guid id)
        {
            var DailyTasks = DailyTaskrepository.Where(b => b.CageId.Equals(id)).ToList();
            return DailyTasks;
        }

        public Task<DailyTask> GetDailyTaskById(Guid id)
        {
            var DailyTask = DailyTaskrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(DailyTask);
        }

        public Task<DailyTask> UpdateDailyTask(DailyTask updatedDailyTask)
        {
            var DailyTask = DailyTaskrepository.FirstOrDefault(b => b.Id.Equals(updatedDailyTask.Id));
            DailyTaskrepository.ToList().Remove(DailyTask);
            DailyTaskrepository.ToList().Add(updatedDailyTask);
            return Task.FromResult(updatedDailyTask);
        }
    }
}
