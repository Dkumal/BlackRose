using Microsoft.AspNetCore.Mvc;
using Black_Rose.helper;
using Black_Rose.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net;


namespace Black_Rose.Controllers
{
    public class AuthController : Controller
    {
        private IConfiguration configuration;
        private AuthRepo auth;
        private EncDec encDec;
        public AuthController(IConfiguration iconfig)
        {
            configuration = iconfig;
            auth = new AuthRepo(configuration);
            encDec = new EncDec(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {

            int RoleID = auth.ValidateUser(username, password);
            if (RoleID != 0)
            {
                var token = GenerateJwtToken(username, RoleID.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        private string GenerateJwtToken(string username, string RoleID)
        {
            // Create claims for the user (customize based on your needs)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, RoleID)
            };

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
