using Imi.Project.Blazor.Models.Quiz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<List<Room>> ShowAvailableRooms();
        public Task<List<Room>> ShowAllRooms();
        public bool UpdateGameStats(string roomId, Player player);
        public void AddRoom(string roomdId, string name, string maxPlayers, Player player);
        public Room GetById(string roomdId);
        public bool AddPlayer(string roomId, Player player);
        public void DisposeRoom(string roomId);
    }
}
