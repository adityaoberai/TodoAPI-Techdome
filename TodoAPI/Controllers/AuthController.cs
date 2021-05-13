using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserContext _context;

        public AuthController(UserContext context)
        {
            _context = context;
        }

        // POST auth/login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user.UserName == null || user.UserName == String.Empty)
            {
                return BadRequest(new { message = "User name needs to entered" });
            }
            else if (user.Password == null || user.Password == String.Empty)
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            user = await LoginUser(user.UserName, user.Password);
            user.Token = "Bearer " + user.Token;
            if (user.Token == null || user.Token == String.Empty)
            {
                return BadRequest(new { message = "User name or password is incorrect" });
            }

            return Ok(user);
        }

        public async Task<ActionResult<TodoItem>> Register([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch(ArgumentException e)
            {
                return BadRequest(new { message = "User already exists" });
            }

            user = await LoginUser(user.UserName, user.Password);
            user.Token = "Bearer " + user.Token;
            if (user.Token == null || user.Token == String.Empty)
            {
                return BadRequest(new { message = "User name or password is incorrect" });
            }

            return Ok(user);
        }

        public async Task<User> LoginUser(string UserName, string Password)
        {
            User user = await _context.Users.FindAsync(UserName);

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.JWTSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Name, user.LastName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;

            return user;
        }
    }
}
