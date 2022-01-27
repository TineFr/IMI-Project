using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models.Quiz
{
    public class QuizElement
    {
        public string Question { get; set; }
        public string Image { get; set; }
        public List<QuizAnswer> PossibleAnswers { get; set; }
    }
}
