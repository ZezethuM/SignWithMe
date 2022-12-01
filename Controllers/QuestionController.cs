using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionController : ControllerBase
    {
         private readonly ILogger<QuestionController> _logger;
        private IQuestions Que;
    public QuestionController(ILogger<QuestionController> logger, IQuestions pQue)
    {
        _logger = logger;
         Que = pQue;
    }
    
    [HttpGet]
    public IActionResult GetAllSigns()
    {
        return Ok(Que.GetAllQuestions());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetQuestionByid(int id)
    {
        var que = Que.GetQuestionById(id);
        return Ok(que);
    }

    [HttpPost]
    public IActionResult AddQuestionPost(Question pQue)
    {
       Que.AddQuestion(pQue);
       return Ok(pQue);
    }
    }
}