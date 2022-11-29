using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Repository
{
    public class SignsRepo : ISigns
    {
        public void AddSign(Sign sign)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sign> GetAllSigns()
        {
            throw new NotImplementedException();
        }

        public Sign GetSignByAlphabet(string Alphabet)
        {
            throw new NotImplementedException();
        }
    }
}