using Imi.Project.Blazor.Models.Quiz;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class RoomService : IRoomService
    {
        private readonly List<Room> Rooms = new List<Room>()
        {

        };
        public void AddRoom(string roomId, string name, int maxPlayers, Player player)
        {
            Rooms.Add(new Room(roomId, name, maxPlayers, player ));
        }

        public void DisposeRoom(string roomId)
        {
            var room = Rooms.SingleOrDefault(r => r.Id == roomId);
            Rooms.Remove(room);
        }

        public bool AddPlayer(string roomId, Player player)
        {
            var room = Rooms.SingleOrDefault(r => r.Id == roomId);
            room.AddPlayer(player);
            Rooms.Remove(room);
            Rooms.Add(room);
            if (room.Players.Count == room.maxPlayerAmount) return true;
            else return false;
        }

        public Task<List<Room>> ShowAllRooms()
        {
            return Task.FromResult(Rooms.OrderBy(r => r.Name).ToList());
        }

        public Task<List<Room>> ShowAvailableRooms()
        {
            return Task.FromResult(Rooms.Where(r => r.Players.Count < r.maxPlayerAmount).OrderBy(r => r.Name).ToList());
        }

        public Room GetById(string roomdId)
        {
            return Rooms.FirstOrDefault(r => r.Id == roomdId);
        }

        public bool UpdateGameStats(string roomId, Player player)
        {
            var room = Rooms.SingleOrDefault(r => r.Id == roomId);
            room.RemovePlayer(player);
            room.AddPlayer(player);
            if (room.Players.Where(p => p.IsFinished).ToList().Count == room.maxPlayerAmount) return true;
            else return false;

        }
    }
}
