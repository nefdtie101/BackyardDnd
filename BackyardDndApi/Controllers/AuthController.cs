using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface;

namespace BackyardDndApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICreateUserInterface _createUserInterface;

        public AuthController
        (
            ICreateUserInterface createUserInterface
        )
        {
            _createUserInterface = createUserInterface;
        }
        
        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if (_createUserInterface != null && _createUserInterface.Login(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@1234"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken
                (
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(4),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}