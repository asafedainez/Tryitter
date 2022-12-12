using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Tryitter.Context;
using Tryitter.Models;
using Tryitter.Services;

namespace Tryitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public LoginController(AppDbContext context, ITokenService tokenService, IConfiguration configuration)
        {
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLogin UserLogin)
        {
            if (UserLogin == null)
            {
                return BadRequest();
            }

            var user = _context.Users.FirstOrDefault<User>(u =>
            u.Email == UserLogin.Email
            && u.Password == UserLogin.Password);

            if (user != null)
            {
                var tokenString = _tokenService.GenerateToken(
                    _configuration.GetValue<string>("JWT:Key"),
                    _configuration.GetValue<string>("JWT:Issuer"),
                    _configuration.GetValue<string>("JWT:Audience"),
                    user);

                return Ok(new { token = tokenString });
            }

            return BadRequest();
        }
    }
}
