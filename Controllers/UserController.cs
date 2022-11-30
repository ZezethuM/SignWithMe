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
    [Route("api/users")]
    public class UserController: ControllerBase
    {
    private readonly ILogger<UserController> _logger;
    private IUser users;
    public UserController(ILogger<UserController> logger, IUser pUsers)
    {
        _logger = logger;
        users = pUsers;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(users.GetAllUsers());
    }
    
    [HttpGet("{username}")]
    public IActionResult GetUserByName(string username)
    {
        var user = users.UserbyName(username);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUserPost(User user)
    {
        //if(users.AuthUser(user))
        //{
             users.AddUser(user);
             return Ok(user);
        //}
       //return Unauthorized();
    }
    }
    
}