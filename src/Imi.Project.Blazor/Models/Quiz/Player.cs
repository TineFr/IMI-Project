using System;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsFinished { get; set; }
        public string ConnectionId { get; set; }


        public Player()
        {

        }

        public Player(string connectionId, string name)
        {
            ConnectionId = connectionId;
            Name = name;
        }

        public void AddScore(int score)
        {
            Score = score;  
        }

    }
}
