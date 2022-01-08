using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser newUser = new ApplicationUser
            {
                Id = new Guid(),
                Email = registration.Email,
                UserName = registration.Email,
                NormalizedEmail = (registration.Email).ToUpper(),
                NormalizedUserName = (registration.Email).ToUpper(),
                FirstName = registration.FirstName,
                Name = registration.Name,
                DateOfBirth = registration.DateOfBirth
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            newUser = await _userManager.FindByEmailAsync(registration.Email);
            await _userManager.AddClaimAsync(newUser,
            new Claim("registration-date", DateTime.UtcNow.ToString("yy-MM-dd")));
            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false,
            lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Password and/or username are incorrect.\nNote the capitalization (lowercase/uppercase)");
            }
            var applicationUser = await _userManager.FindByEmailAsync(login.Email);
            JwtSecurityToken token = await GenerateTokenAsync(applicationUser);
            string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginResponseDto()
            {
                JWT = serializedToken
            });
        }
        private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>();
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            var roleClaims = await _userManager.GetRolesAsync(user);
            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var expirationDays = _configuration.GetValue<int>("JWTConfig:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfig:SigningKey"));
            var token = new JwtSecurityToken
            (
            issuer: _configuration.GetValue<string>("JWTConfig:Issuer"),
            audience: _configuration.GetValue<string>("JWTConfig:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey),
            SecurityAlgorithms.HmacSha256));
            return token;
        }

    }
}
