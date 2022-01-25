using System;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public string maxPlayerAmount { get; set; } = "2";

        public Room()
        {

        }

        public Room(string roomId, string name, string maxPlayerAmount)
        {
            this.Name = name;
            Id = roomId;
            this.maxPlayerAmount = maxPlayerAmount;
        }

        public Room(string name, string maxPlayerAmount)
        {
            this.Name = name;
            this.maxPlayerAmount = maxPlayerAmount;
        }

        public Room(string roomId, string name, string maxPlayers, Player player)
        {
            this.Id = roomId;
            this.Name = name;
            this.maxPlayerAmount = maxPlayers;
            Players.Add(player);
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
