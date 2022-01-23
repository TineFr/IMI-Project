using Imi.Project.Blazor.Models.Quiz;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IRoomService
    {
        public List<Room> ShowAvailableRooms();
        public List<Room> ShowAllRooms();
        public void AddRoom();
        public void DisposeRoom();
    }
}
