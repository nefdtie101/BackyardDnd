using System.Net;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace BackyardDndApi.Controllers
{
    
    public class CreateUser : Controller
    {
        
            
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
         return 
        }
    }
}