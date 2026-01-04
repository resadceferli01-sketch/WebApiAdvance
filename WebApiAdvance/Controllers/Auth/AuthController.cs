using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using WebApiAdvance.DAL.Migrations;
using WebApiAdvance.Entities.Auth;
using WebApiAdvance.Entities.DTOs;
using WebApiAdvance.Entities.DTOs.Auth;

namespace WebApiAdvance.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser<Guid>> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenOption _tokenOption;



        public AuthController(UserManager<AppUser<Guid>> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _config = config;
            _tokenOption = _config.GetSection("TokenOptions").Get<TokenOption>();
        }


        [HttpPost]

        public async Task<IActionResult> Register(RegisterDto register)
        {
            var user = _mapper.Map<AppUser<Guid>>(register);
            var resultUser = await _userManager.CreateAsync(user, register.Password);

            if (!resultUser.Succeeded)
            {
                return BadRequest(new
                {
                    errors = resultUser.Errors,
                    code = 400
                });

            }

            await _roleManager.CreateAsync(new IdentityRole("User"));

            var resultRole = await _userManager.AddToRoleAsync(user, "User");

            if (!resultRole.Succeeded)
            {
                return BadRequest(new
                {
                    errors = resultRole.Errors,
                    code = 400
                });
            }

            return Ok(new
            {
                Message = "User registered successfully",
                code = 200
            });



        }




        [HttpPost]

        public async Task<IActionResult> Login(LoginDto login)
        {
            AppUser<Guid> user = await  _userManager.FindByNameAsync(login.UserName);

            if(user is null)
            {
                return NotFound();
            }

           bool isValidPassword =  await _userManager.CheckPasswordAsync(user, login.Password);

            if (!isValidPassword)
            {
                return Unauthorized();
            }


            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            JwtHeader header = new JwtHeader(signingCredentials);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("FullName",user.Email)

            };
            foreach (var userRole in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            JwtPayload payload = new JwtPayload(audience: _tokenOption.Audience, issuer: _tokenOption.Issuer, claims: claims, expires: DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration), notBefore: DateTime.UtcNow);
            JwtSecurityToken token = new JwtSecurityToken(header,payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string jwt = handler.WriteToken(token);
            return Ok(new
            {
                Token = jwt,
                StatusCode = 200,
            });
                






        }




    }
}