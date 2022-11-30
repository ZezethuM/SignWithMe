using Microsoft.AspNetCore.Mvc;

namespace SignWithMe.Controllers;

[ApiController]
[Route("api/sign")]
public class SignController : ControllerBase
{
    private readonly ILogger<SignController> _logger;

    public SignController(ILogger<SignController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllSigns()
    {
        return Ok();
    }
    
    [HttpGet("{name}")]
    public IActionResult GetSignByName(string name)
    {
        return Ok();
    }
}
