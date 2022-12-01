using Microsoft.AspNetCore.Mvc;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Controllers;

[ApiController]
[Route("api/signs")]
public class SignController : ControllerBase
{
    private readonly ILogger<SignController> _logger;
    private ISigns signs;
    public SignController(ILogger<SignController> logger, ISigns pSigns)
    {
        _logger = logger;
        signs = pSigns;
    }

    [HttpGet]
    public IActionResult GetAllSigns()
    {
        return Ok(signs.GetAllSigns());
    }
    
    [HttpGet("{alphabet}")]
    public IActionResult GetSignByAlphabet(string alphabet)
    {
        var sign= signs.GetSignByAlphabet(alphabet);
        return Ok(sign);
    }

    [HttpPost]
    public IActionResult AddSignPost(Sign sign )
    {
        signs.AddSign(sign);
        return Ok(new{sign});
    }
/*
     [HttpPut]
    public IActionResult UpdateSign(Sign sign )
    {
        signs.UpdateSign(sign);
        return Ok(new{sign});
    }
    */
}
