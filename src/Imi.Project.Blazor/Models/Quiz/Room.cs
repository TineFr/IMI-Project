using System;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();


        public int maxPlayerAmount { get; set; }



        public Room(string roomId, string name, int maxPlayerAmount)
        {
            this.Name = name;
            Id = roomId;
            this.maxPlayerAmount = maxPlayerAmount;
        }

        public Room(string name, int maxPlayerAmount, int playerAmount)
        {
            this.Name = name;
            this.maxPlayerAmount = maxPlayerAmount;
        }

        public Room(string roomId, string name, int maxPlayers, Player player)
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
    }
}
