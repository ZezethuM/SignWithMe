using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignWithMe.Models
{
  public class Words
  {
    public int Id { get; set; }
    public string? Word { get; set; }
    public string? ImageFile { get; set; }
    //public IFormFile? Upload { get; set; }
  }
}