using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Models;

namespace SignWithMe.Interfaces
{
    public interface ISigns
    {
        IEnumerable<Sign> GetAllSigns();
        Sign GetSignByAlphabet(string Alphabet);
        void AddSign(Sign sign);
        //void UpdateSign(Sign sign);
    }
}