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
                //UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName =register.UserName = register.FirstName + register.LastName
            };
            var result = await _userManager.CreateAsync(guest, register.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(guest);
                return Ok(new { message = $"Please Confirm Your Email Whth Code You Have Recieved ", code });
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("Password",item.Description);
            }
            return BadRequest(ModelState);

        }
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            if (email == null || code == null) 
            {
                return BadRequest("In-Valid Date");
            }
            // check email exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("In-Valid Date");
            }
            // check code
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return Ok("Email Confirmed");
            }
            return BadRequest("Some Thing Went Wrong");
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
                            new (ClaimTypes.NameIdentifier,user.Id),
                            new (ClaimTypes.Email,user.Email),
                            new ("Rooms","Customer"),
                            new ("Admins","Admin"),
                            new ("Admins","Onwer"),
                        };

                 

                    var smKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var signCred = new SigningCredentials(smKey, SecurityAlgorithms.HmacSha256);
                    var myToken = new JwtSecurityToken
                    (
                        issuer: _config["JWT:Issuer"],
                        audience: _config["JWT:Audience"],
                        expires: DateTime.Now.AddDays(2),
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
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return BadRequest("In-Valid Data");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if(string.IsNullOrEmpty(token)) return BadRequest("Something Went Wrong");

            return Ok(new {
                token,
                email = user.Email

            });
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return BadRequest("In-Valid Date");
            var result = await _userManager.ResetPasswordAsync(user,dto.Token,dto.Password);
            if (result.Succeeded)
            {
                return Ok("Password Reset Is Succssfully");
            }
            return BadRequest("Something Went Wrong");

        }
    }
}
