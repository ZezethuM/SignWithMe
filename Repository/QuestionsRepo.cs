using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Repository
{
    public class QuestionsRepo : IQuestions
    {
        public void AddQuestion(Question pQuestion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllSigns()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}