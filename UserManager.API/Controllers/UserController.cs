using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserDataAccess.Models;
using UserDataAccess.Services;
using UserManager.API.Extensions;
using UserManager.API.Messages;
using UserManager.API.Models;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public UserController(ITokenService tokenService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Father = registerDto.Father,
                PhoneNumber=registerDto.Phone,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { error = false, message = "Registration successful." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();

            var token = await _tokenService.GenerateTokenAsync(user);

            HttpContext.AppendTokenToCookie(token, user.UserName!);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserData()
        {
            var username= User.FindFirst("userName")?.Value;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return Unauthorized();

            UserDTO userDTO = new UserDTO()
            {
                UserName = user.UserName,
                Email=user.Email,
                Phone=user.PhoneNumber,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Father=user.Father
            };

            return Ok(userDTO);
        }

        [HttpGet("check-auth")]
        [Authorize]
        public IActionResult CheckAuth()
        {
            return Ok();
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            Response.Cookies.Delete("userId");
            return Ok();
        }
    }
}
