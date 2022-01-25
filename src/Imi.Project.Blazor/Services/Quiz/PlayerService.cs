using Imi.Project.Blazor.Models.Quiz;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly List<Player> Players = new List<Player>();

        public void AddPlayer(Player player)
        {
             Players.Add(player);
        }

        public void DisposePlayer(string id)
        {
            Players.Remove(Players.FirstOrDefault(p => p.ConnectionId == id));
        }

        public Task<List<Player>> GetPlayers()
        {
           return Task.FromResult(Players);
        }

        public void PlayerIsFinished(string id, int score)
        {
            var player = Players.FirstOrDefault(p => p.ConnectionId == id);
            player.IsFinished = true;
            player.Score = score;
            Players.Remove(player);
            Players.Add(player);
        }
    }
}
