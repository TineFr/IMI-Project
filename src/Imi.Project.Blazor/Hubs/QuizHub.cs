using Microsoft.AspNetCore.SignalR;
using System;

namespace Imi.Project.Blazor.Hubs
{
    public class QuizHub : Hub
    {
        public async void JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.GroupExcept(roomId, Context.ConnectionId).SendAsync("TableJoined");
        }
    }
}
