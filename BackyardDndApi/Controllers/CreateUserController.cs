using System.Net;
using BackyardDndApi.Model;
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
    }
}