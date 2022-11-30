using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignWithMe.Models
{
    public class Sign
    {
        public int Id { get; set; }
        public string? Alphabet { get; set; }
        public string? ImageFile { get; set; }
        //public IFormFile? Upload { get; set; }
    }
}