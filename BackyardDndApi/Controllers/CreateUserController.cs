using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [Authorize]
        [Route("Create User")]
        public IActionResult SaveUser([FromBody] User user)
        {
            _createUserInterface.AddUser(user);
            return Ok("hierdie Kak werk");
        }

        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            var res = new Test
            {
                testString = "bla bla"
            };
            return Ok(res);
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult Login(User user)
        {
            return Ok(_createUserInterface.Login(user) == true ? "Logged In" : "Login Failed!");
        }
    }
}