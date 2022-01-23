using Imi.Project.Blazor.Models.Quiz;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Imi.Project.Blazor.Services
{
    public class RoomService : IRoomService
    {

        private readonly List<Room> Rooms = new List<Room>()
        {
            new Room("Room 1", 2),
            new Room("Room 2",2),
            new Room("Room 3",2),
        };
        public void AddRoom()
        {
            throw new System.NotImplementedException();
        }

        public void DisposeRoom()
        {
            throw new System.NotImplementedException();
        }

        public List<Room> ShowAllRooms()
        {
            return Rooms;
        }

        public List<Room> ShowAvailableRooms()
        {
            return Rooms.Where(r => r.playerAmount < r.maxPlayerAmount).ToList();
        }
    }
}
