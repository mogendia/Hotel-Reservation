using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hotel_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController(UserManager<Guest> _userManager, IConfiguration _config) : ControllerBase
    {

       

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
           if(!ModelState.IsValid) return BadRequest(ModelState);
            Guest guest = new()
            {
                Email = register.Email,
                UserName = register.UserName,
            };
            var result = await _userManager.CreateAsync(guest, register.Password);
            if (result.Succeeded) return Ok(result);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("Password",item.Description);
            }
            return BadRequest(ModelState);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is not null)
            {
                var check = await _userManager.CheckPasswordAsync(user, login.Password);
                if (check)
                {
                    var userClaims = new List<Claim>
                        {
                            //new (ClaimTypes.NameIdentifier,user.Id),
                            new (ClaimTypes.Email,user.Email),
                        };


                    var smKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var signCred = new SigningCredentials(smKey, SecurityAlgorithms.HmacSha256);
                    var myToken = new JwtSecurityToken
                    (
                        issuer: _config["JWT:Issuer"],
                        audience: _config["JWT:Audience"],

                        expires: DateTime.Now.AddHours(1),
                        claims: userClaims,
                        signingCredentials: signCred
                    );
                   
                    await _userManager.UpdateAsync(user);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(myToken),
                        expiresIn = DateTime.Now.AddHours(1),
                    });

                }

            }
            ModelState.AddModelError("UserName", "UserName or Passord Not Valid");
            return BadRequest(ModelState);
        }
    }
}
