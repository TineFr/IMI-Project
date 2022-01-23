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
            new Room("Room 1", 2, 0),
            new Room("Room 2",2, 0),
            new Room("Room 3",2, 0),
        };
        public void AddRoom(string roomId, string name, int maxPlayers)
        {
            Rooms.Add(new Room(roomId, name, maxPlayers));
        }

        public void DisposeRoom(string roomId)
        {
            var room = Rooms.SingleOrDefault(r => r.Id == roomId);
            Rooms.Remove(room);
        }

        public void AddPlayer(string roomId)
        {
            var room = Rooms.SingleOrDefault(r => r.Id == roomId);
            var newroom = room.playerAmount++;
            Rooms.Remove(room);
            Rooms.Add(room);
        }

        public Task<List<Room>> ShowAllRooms()
        {
            return Task.FromResult(Rooms.OrderBy(r => r.Name).ToList());
        }

        public Task<List<Room>> ShowAvailableRooms()
        {
            return Task.FromResult(Rooms.Where(r => r.playerAmount < r.maxPlayerAmount).OrderBy(r => r.Name).ToList());
        }
    }
}
