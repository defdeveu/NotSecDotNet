using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.Model;
using NotSecDotNet.Services;
using System.Security.Claims;

namespace NotSecDotNet.Controllers
{

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MovieDbContext dbContext;
        private readonly UserService userService;

        public AuthController(MovieDbContext dbContext, UserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IResult> Login(LoginDto login)
        {
            User? user = userService.FindUserByName(login.UserName);
            if(user != null)
            {
                if(user.Password == login.Password)
                {
                    List<Claim> claims = new()
                    {
                        new Claim("username", login.UserName),
                        new Claim("sex", user.Sex ?? ""),
                        new Claim("email", user.EmailAddress ?? ""),
                        new Claim("userId", user.Id.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return Results.Ok(login.UserName);
                }
            }
            
            return Results.Unauthorized();     
        }

        [Authorize]
        [Route("logout")]
        [HttpGet]
        public async Task<IResult> Logout()
        {
            await HttpContext.SignOutAsync("cookie");
            return Results.Ok();
        }
    }
}
