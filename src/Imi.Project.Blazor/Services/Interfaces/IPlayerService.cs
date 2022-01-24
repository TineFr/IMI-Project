using Imi.Project.Blazor.Models.Quiz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IPlayerService
    {
        public void AddPlayer(Player player);
        public void DisposePlayer(string id);

        public Task<List<Player>> GetPlayers();
    }
}
