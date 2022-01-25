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
            await Clients.All.SendAsync("PlayerJoined");
            var result = _roomService.AddPlayer(roomId, player);
            if (result) await StartQuiz(roomId);

        }

        public async Task CreateRoom(string roomId, string name, string maxPlayers)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("OnCreation", roomId);
            await Clients.All.SendAsync("RoomAdded");
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            _roomService.AddRoom(roomId, name, maxPlayers, player);

        }

        public async Task StartQuiz(string roomId)
        {
            var questions = quizService.CreateQuiz();
            string list = JsonConvert.SerializeObject(questions);
            await Clients.Group(roomId).SendAsync("OnStart", list);

        }

        public async void RegisterPlayer(string name, string avatar)
        {
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            if (player == null)
            {
                player = new Player(Context.ConnectionId, name, avatar);
                _playerService.AddPlayer(player);
            }
            await Clients.Client(Context.ConnectionId).SendAsync("RegisterSuccess");
        }

        public async Task PlayerFinished(string roomId, int score)
        {
            _playerService.PlayerIsFinished(Context.ConnectionId, score);
            var player = (await _playerService.GetPlayers()).ToList().FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            var room = _roomService.GetById(roomId);
            var quizFinished = _roomService.UpdateGameStats(roomId, player);
            if (quizFinished)
            {
                await Clients.Group(roomId).SendAsync("QuizFinished");
                for     (int i = 0; i < room.Players.Count(); i++)
                {
                    await Groups.RemoveFromGroupAsync(room.Players[i].ConnectionId, roomId);
                }
                _roomService.DisposeRoom(roomId);
            }
        }

        public void PlayerLeft()
        {
             _playerService.DisposePlayer(Context.ConnectionId);
             Context.Abort();
        }

        public void ResetPlayerStats()
        {
            _playerService.ResetStats(Context.ConnectionId);
        }
    }
}
