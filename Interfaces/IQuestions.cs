using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Models;

namespace SignWithMe.Interfaces
{
    public interface IQuestions
    {
        IEnumerable<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        void AddQuestion(Question pQuestion );
    }
}