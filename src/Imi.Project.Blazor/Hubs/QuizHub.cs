using Imi.Project.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Imi.Project.Blazor.Hubs
{
    public class QuizHub : Hub
    {
        private readonly IRoomService _roomService;

        public QuizHub(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public async void JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.GroupExcept(roomId, Context.ConnectionId).SendAsync("TableJoined");
            _roomService.AddPlayer(roomId);
        }

        public async void CreateRoom(string roomId, string name, int maxPlayers)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            _roomService.AddRoom(roomId, name, maxPlayers);

        }
    }
}
