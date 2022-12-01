using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Models;

namespace SignWithMe.Interfaces
{
  public interface IWords
  {
    IEnumerable<Words> GetAllSigns();
    Words GetSignByAlphabet(string Word);
    void AddSign(Words words);
  }
}