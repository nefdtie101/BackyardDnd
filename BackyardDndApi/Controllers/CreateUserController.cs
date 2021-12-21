using System.Collections;
using System.Collections.Generic;
using System.Net;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace BackyardDndApi.Controllers
{

    public class CreateUserController : Controller
    {
        private readonly ICreateUserInterface _createUserInterface;

        public CreateUserController(
            ICreateUserInterface createUserInterface
        )
        {
            _createUserInterface = createUserInterface;
        }

        [HttpPost]
        [Route("Create User")]
        public IActionResult SaveUser([FromBody] User user)
        {
            _createUserInterface.AddUser(user);
            return Ok("hierdie Kak werk");
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult Login(string Username, string Password)
        {
            bool bTrue = _createUserInterface.Login(Username, Password);
            if (bTrue == true)
            {
                return Ok("Logged In");
            }
            else
            {
                return Ok("Login Failed!");
                 
            }
        }
        
        [HttpPost]
        [Route("Create Player")]
        public IActionResult SavePlayer([FromBody] PlayerForm pForm)
        {
            _createUserInterface.AddPlayer(pForm);
            return Ok("hierdie Kak werk");
        }

        [HttpGet]
        [Authorize]
        [Route("Authorize")]
        public IEnumerable<string> Get() => new string[]
        {
            "John Doe", "Jane Doe"
        };
    }
}