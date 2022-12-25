using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeWorkoutBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly HomeWorkoutContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountController(HomeWorkoutContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser(RegisterDto dto)
        {
            var email = _context.Users.FirstOrDefault(a => a.Email== dto.Email);
            if (email != null)
            {
                return BadRequest("Address email already taken!");
            }

            User newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Gender = dto.Gender,
                Role = dto.Role
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto dto)
        {
            var user = _context
                .Users
                .AsNoTracking()          
                .FirstOrDefault(e => e.Email == dto.Email);
            if (user is null)
            {
                BadRequest("Invalid email or password!");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                BadRequest("Invalid email or password!");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            var result2 =  tokenHandler.WriteToken(token);
            return Ok(result2);
        }
    }
}
