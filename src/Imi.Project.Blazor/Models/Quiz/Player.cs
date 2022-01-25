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
        public string Avatar { get; set; } = "images/quiz/avatars/";


        public Player()
        {

        }

        public Player(string connectionId, string name, string avatar)
        {
            ConnectionId = connectionId;
            Name = name;
            Avatar += avatar;
        }

        public void AddScore(int score)
        {
            Score = score;  
        }

    }
}
