using Imi.Project.Blazor.Models.Quiz;
using Imi.Project.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Hubs
{
    public class QuizHub : Hub
    {
        private readonly IRoomService _roomService;
        private readonly IQuizService quizService;
        public QuizHub(IRoomService roomService, IQuizService quizService)
        {
            _roomService = roomService;

            this.quizService = quizService;
        }
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("OnJoin", roomId);
            var result = _roomService.AddPlayer(roomId);
            if (result) await StartQuiz(roomId);

        }

        public async Task CreateRoom(string roomId, string name, int maxPlayers)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            _roomService.AddRoom(roomId, name, maxPlayers);

        }

        public async Task StartQuiz(string roomId)
        {
            var questions = quizService.CreateQuiz();
            string list = JsonConvert.SerializeObject(questions);
            await Clients.Group(roomId).SendAsync("OnStart", list);

        }


    }
}
