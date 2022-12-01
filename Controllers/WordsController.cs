using Microsoft.AspNetCore.Mvc;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Controllers;

[ApiController]
[Route("api/words")]
public class WordsController : ControllerBase
{
  private readonly ILogger<WordsController> _logger;
  private IWords words;
  public WordsController(ILogger<WordsController> logger, IWords pWord)
  {
    _logger = logger;
    words = pWord;
  }

  [HttpGet]
  public IActionResult GetAllSigns()
  {
    return Ok(words.GetAllSigns());
  }

  [HttpGet("{alphabet}")]
  public IActionResult GetSignByAlphabet(string alphabet)
  {
    var word = words.GetSignByAlphabet(alphabet);
    return Ok(word);
  }

  [HttpPost]
  public IActionResult AddSignPost(Words word)
  {
    words.AddSign(word);
    return Ok(new { word });
  }
}
