using System;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public int playerAmount { get; set; } = 1;

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
            this.playerAmount = playerAmount;
        }
    }
}
