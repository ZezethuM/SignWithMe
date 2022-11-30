using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignWithMe.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Level { get; set; }
        public string? Score { get; set; }
        public string? Result { get; set; }
    }
}