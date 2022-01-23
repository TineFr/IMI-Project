using Imi.Project.Blazor.Models.Quiz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<List<Room>> ShowAvailableRooms();
        public Task<List<Room>> ShowAllRooms();
        public void AddRoom(string roomdId, string name, int maxPlayers);
        public void AddPlayer(string roomId);
        public void DisposeRoom(string roomId);
    }
}
