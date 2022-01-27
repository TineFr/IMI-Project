using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(15, ErrorMessage = "Name can not be longer than 15 characters")]
        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public string MaxPlayerAmount { get; set; } = "2";

        public Room()
        {

        }

        public Room(string roomId, string name, string maxPlayerAmount)
        {
            this.Name = name;
            Id = roomId;
            this.MaxPlayerAmount = maxPlayerAmount;
        }

        public Room(string name, string maxPlayerAmount)
        {
            this.Name = name;
            this.MaxPlayerAmount = maxPlayerAmount;
        }

        public Room(string roomId, string name, string maxPlayers, Player player)
        {
            this.Id = roomId;
            this.Name = name;
            this.MaxPlayerAmount = maxPlayers;
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
