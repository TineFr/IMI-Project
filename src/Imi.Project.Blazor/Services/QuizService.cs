using Imi.Project.Blazor.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class QuizService
    {
        private static IEnumerable<QuizElement> QuestionsRepository = new List<QuizElement>
        {
                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"
                        
                    },

                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"

                    },

                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"

                    },

                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"

                    },
                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"

                    },
        };
    }
}
