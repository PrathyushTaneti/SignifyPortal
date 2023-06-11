using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server.Models;
using server.Utility.ApiRoute;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Controllers
{
    [Route(GetApiRoute.DefaultRoute)]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] Login login, [FromServices] DataContext dataContext)
        {
            if (login is null)
            {
                return BadRequest("Invalid Login");
            }
            else
            {
                bool isPresent = dataContext.Admins.Any(admin => admin.UserName == login.UserName && admin.Password == login.Password);
                if (isPresent)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AbdulRahman@786."));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.UserName),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:7100",
                        audience: "https://localhost:7100",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials : signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
                return Unauthorized();
            }
        }
    }
}
