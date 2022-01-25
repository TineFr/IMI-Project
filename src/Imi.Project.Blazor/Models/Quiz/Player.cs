using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class Player
    {
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(15 , ErrorMessage = "Name can not be longer than 15 characters")]
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
