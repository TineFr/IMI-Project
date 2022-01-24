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
        private readonly IPlayerService _playerService;
        private readonly IRoomService _roomService;
        private readonly IQuizService quizService;
        public QuizHub(IRoomService roomService, IQuizService quizService, IPlayerService playerService)
        {
            _roomService = roomService;

            this.quizService = quizService;
            _playerService = playerService;
        }
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            await Clients.Group(roomId).SendAsync("OnJoin", roomId);
            var result = _roomService.AddPlayer(roomId, player);
            if (result) await StartQuiz(roomId);

        }

        public async Task CreateRoom(string roomId, string name, int maxPlayers)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("OnCreation", roomId);
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            _roomService.AddRoom(roomId, name, maxPlayers, player);

        }

        public async Task StartQuiz(string roomId)
        {
            var questions = quizService.CreateQuiz();
            string list = JsonConvert.SerializeObject(questions);
            await Clients.Group(roomId).SendAsync("OnStart", list);

        }

        public async void RegisterPlayer(string name)
        {
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            if (player == null)
            {
                player = new Player(Context.ConnectionId, name);
                _playerService.AddPlayer(player);
            }
            await Clients.Client(Context.ConnectionId).SendAsync("RegisterSuccess");
        }


        public async Task PlayerFinished()
        {
            //_playerService.PlayerIsFinished(Context.ConnectionId);


        }


    }
}
