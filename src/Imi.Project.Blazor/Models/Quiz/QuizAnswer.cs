using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class QuizAnswer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public QuizAnswer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}
