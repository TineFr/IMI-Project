using Imi.Project.Blazor.Models.Quiz;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class QuizService : IQuizService
    {
        private static IEnumerable<QuizElement> questionsRepository = new List<QuizElement>
        {
                    new QuizElement
                    {
                        Question = "Which bird is the national bird of the USA?",
                        Image = "images/quiz/americanflag.png",
                        PossibleAnswers = new List<string>()
                        {
                            "Bald eagle", "Golden eagle", "Raven", "Mockingbird"
                        },
                        CorrectAnswer="Bald eagle"
                        
                    },

                    new QuizElement
                    {
                        Question = "Test question?",
                        Image = "images/quiz/logolightnotext.png",
                        PossibleAnswers = new List<string>()
                        {
                            "Test", "Test", "Raven", "Mockingbird"
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


        public Task<IEnumerable<QuizElement>> GetAllAsync()
        {
            return Task.FromResult(questionsRepository);
        }
    }
}
