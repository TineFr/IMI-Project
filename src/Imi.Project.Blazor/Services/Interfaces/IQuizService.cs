using Imi.Project.Blazor.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizElement>> GetAllAsync();

        List<QuizElement> CreateQuiz();

    }
}
