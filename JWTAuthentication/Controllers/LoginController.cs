using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginRepository _login;
        public LoginController(IConfiguration config,ILoginRepository login)
        {
            _config = config;
            _login = login;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            IActionResult responce = Unauthorized();
            var user = Authenticate(model);
            if(user!=null)
            {
                var tokenString = BuildToken(user);
                responce = Ok(new { token = tokenString });
            }
            else
            {

                responce= BadRequest(new { message = "Username or password is incorrect" });
            }
            return responce;

        }

        private Login Authenticate(LoginModel model)
        {
            Login user = _login.ValidateLogin(model.UserName,model.Password);

            return user;
        }
        private string BuildToken(Login userdetails)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var cread = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], expires: DateTime.Now.AddHours(2), signingCredentials: cread);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}