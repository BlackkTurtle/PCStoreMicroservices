﻿using System.IdentityModel.Tokens.Jwt;
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
using UserManager.API.Messages;
using UserManager.API.Models;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string secureKey = "odneivkdivrenekjwjfdw8232jene";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMessageProducer messageProducer;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMessageProducer messageProducer)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.messageProducer = messageProducer;
        }
        [HttpPost]
        [Route("roles/add")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var appRole = new ApplicationRole { Name = request.Role };
            var createRole = await _roleManager.CreateAsync(appRole);

            return Ok(new { message = "role created succesfully" });
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await RegisterAsync(request);

            return result.Success ? Ok(result) : BadRequest(result.Message);

        }
        private async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(request.Email);
                if (userExists != null) return new RegisterResponse { Message = "User already exists", Success = false };

                //if we get here, no user with this email..

                userExists = new ApplicationUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Father = request.Father,
                    PhoneNumber = request.Phone,
                    Email = request.Email,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email,

                };
                var createUserResult = await _userManager.CreateAsync(userExists, request.Password);
                if (!createUserResult.Succeeded) return new RegisterResponse { Message = $"Create user failed {createUserResult?.Errors?.First()?.Description}", Success = false };
                //user is created...
                //then add user to a role...
                var addUserToRoleResult = await _userManager.AddToRoleAsync(userExists, "USER");
                if (!addUserToRoleResult.Succeeded) return new RegisterResponse { Message = $"Create user succeeded but could not add user to role {addUserToRoleResult?.Errors?.First()?.Description}", Success = false };

                //all is still well..
                return new RegisterResponse
                {
                    Success = true,
                    Message = "User registered successfully"
                };
            }
            catch (Exception ex)
            {
                return new RegisterResponse { Message = ex.Message, Success = false };
            }
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await LoginAsync(request);

            if (result.Success)
            {
                var up = new UserPublisher()
                {
                    UserName=request.Email,
                    IsRegistered=true
                };
                messageProducer.SendingMessage<UserPublisher>(up);
            }

            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        private async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null) return new LoginResponse { Message = "Invalid email/password", Success = false };
                var passresult = await _userManager.CheckPasswordAsync(user, request.Password);
                if (passresult == false)
                {
                    return new LoginResponse { Message = "Invalid email/password", Success = false };
                }
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName), 
                     };
                //all is well if ew reach here
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
                var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
                var header = new JwtHeader(credentials);
                var payload = new JwtPayload(user.UserName, null, claims, null, DateTime.Now.AddMinutes(15));
                var token = new JwtSecurityToken(header, payload);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true
                });

                return new LoginResponse
                {
                    Message = "Login Successful",
                    Success = true,
                    UserName = user.UserName,
                    Email = user.Email,
                    token = jwt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new LoginResponse { Success = false, Message = ex.Message };
            }
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<LoginResponse> GetUser()
        {
            try
            {
                string? userName = User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception();
                }
                var user=await _userManager.FindByNameAsync(userName);
                return new LoginResponse
                {
                    Email=user.Email,
                    UserName=userName,
                    Message="success",
                    Success = true
                };
            }
            catch
            {
                return new LoginResponse
                {
                    Message = "unauthorized",
                    Success = false
                };
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message="success"
            });
        }
        [Authorize]
        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string? userName = User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception();
                }
                var user = await _userManager.FindByNameAsync(userName);
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    Response.Cookies.Delete("jwt");
                    return Ok(new LoginResponse
                    {
                        Message = "success",
                        Success = true
                    });
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {
                return Unauthorized(new LoginResponse
                {
                    Message = "unauthorized",
                    Success = false
                });
            }
        }
    }
}
