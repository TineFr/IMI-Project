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
                        PossibleAnswers = new List<QuizAnswer>()
                        {
                            new QuizAnswer("Bald Eagle", true),
                            new QuizAnswer("Golden Eagle", false),
                            new QuizAnswer("Raven", false),
                            new QuizAnswer("Mockingbird", false),
                        }                   
                    },

                    new QuizElement
                    {
                        Question = "What is the world’s smallest living bird?",
                        Image = "images/quiz/beehummingbird.jpg",
                        PossibleAnswers = new List<QuizAnswer>()
                        {
                            new QuizAnswer("Bee Hummingbird", true),
                            new QuizAnswer("Diamond Firetail", false),
                            new QuizAnswer("Grey Fantail", false),
                            new QuizAnswer("Spotted Pardalote", false),
                        }
                    },

                    new QuizElement
                    {
                        Question = "Which bird has the fastest maximum airspeed and is classified as the fastest animal in the world?",
                        Image = "images/quiz/fastestbird.jpg",
                        PossibleAnswers = new List<QuizAnswer>()
                        {    
                            new QuizAnswer("Saker Falcon", false),
                            new QuizAnswer("Golden Eagle", false),
                            new QuizAnswer("Peregrine Falcon", true),
                            new QuizAnswer("Grey-headed Albatross", false),
                        }
                    },

                    new QuizElement
                    {
                        Question = "What is the collective name for a group of crows?",
                        Image = "images/quiz/crows.jfif",
                        PossibleAnswers = new List<QuizAnswer>()
                        {
                            new QuizAnswer("A Wreck", false),
                            new QuizAnswer("A Murder", true),
                            new QuizAnswer("A Flock", false),
                            new QuizAnswer("A Muster", false),
                        }
                    },


                    new QuizElement
                    {
                        Question = "Which birds did coal miners traditionally bring into the mines with them to detect dangerous levels of carbon monoxide?",
                        Image = "images/quiz/mine.jfif",
                        PossibleAnswers = new List<QuizAnswer>()
                        {
                            new QuizAnswer("Robins", false),
                            new QuizAnswer("Blackbirds", false),
                            new QuizAnswer("Canaries", true),
                            new QuizAnswer("Ravens", false),
                        }
                    },


                    //new QuizElement
                    //{
                    //    Question = "What color eggs does a gray catbird lay?",
                    //    Image = "images/quiz/catbird.jfif",
                    //    PossibleAnswers = new List<string>()
                    //    {
                    //        "White", "Blue", "Gray", "Green"
                    //    },
                    //    CorrectAnswer="Blue"

                    //},

                    //new QuizElement
                    //{
                    //    Question = "Pica pica is the scientific name for which bird?",
                    //    Image = "images/quiz/pica.png",
                    //    PossibleAnswers = new List<string>()
                    //    {
                    //        "Eurasian Magpie", "Laughing kookaburra", "Conure", "Cockatoo"
                    //    },
                    //    CorrectAnswer="Eurasian Magpie"

                    //},

                    //new QuizElement
                    //{
                    //    Question = "There is only one bird in the world which has nostrils at the end of its beak. Which is it?",
                    //    Image = "images/quiz/nostrils.jpg",
                    //    PossibleAnswers = new List<string>()
                    //    {
                    //        "Kiwi", "Ostrich", "Southern Cassowary", "Magpie Goose"
                    //    },
                    //    CorrectAnswer="Kiwi"

                    //},
                    //new QuizElement
                    //{
                    //    Question = "The kakapo bird is native to which country?",
                    //    Image = "images/quiz/kakapo.jpg",
                    //    PossibleAnswers = new List<string>()
                    //    {
                    //        "Tanzania", "Papua New Guinea", "India", "New Zealand"
                    //    },
                    //    CorrectAnswer="New Zealand"

                    //},
        };


        public Task<IEnumerable<QuizElement>> GetAllAsync()
        {
            return Task.FromResult(questionsRepository);
        }
    }
}
