using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.model;
using NotSecDotNet.Model;
using NotSecDotNet.Services;
using System.Security.Claims;

namespace NotSecDotNet.Controllers
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {

        MovieDbContext movieDbContext;
        private readonly ILogger<UserController> logger;
        private readonly UserService userService;

        public UserController(MovieDbContext movieDbContext, ILogger<UserController> logger, UserService userService)
        {
            this.movieDbContext = movieDbContext;
            this.logger = logger;
            this.userService = userService;
        }

        [Route("user/password")]
        [HttpPost]
        public String ChangePassword(
            [FromBody] ChangePasswordDto PwdChange)
        {
            PasswordChangeService passwordChangeService = new PasswordChangeService(movieDbContext);
            return passwordChangeService.ChangePassword(PwdChange);
        }

        
        [Route("me")]
        [HttpGet]
        public String Whoami()
        {
            string loggedinuser = HttpContext.User.FindFirstValue("username");
            return loggedinuser;
        }
        
        [Route("user/profile/{userName}")]
        [HttpGet]
        public IResult UserProfile([FromRoute] String userName)
        {
            string loggedinuser = HttpContext.User.FindFirstValue("username");
            if(loggedinuser == userName)
            {
                User u = userService.FindUserByName(userName);
                if(u != null)
                {
                    return Results.Ok(u);
                }
            }
            HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Results.Unauthorized();
        }

        [Route("mytokens")]
        [HttpGet]
        public TokenAccount MyTokens()
        {
            int loggedinuserId = Int16.Parse(HttpContext.User.FindFirstValue("userId"));
            return userService.FindTokenAccount(loggedinuserId);
        }

        [Route("transfertoken")]
        [HttpPut]
        public IResult TransferToken([FromBody] TransferDto transferDto)
        {
            int loggedinuserId = Int16.Parse(HttpContext.User.FindFirstValue("userId"));
            var ret = userService.TransferToken(loggedinuserId, transferDto.ToUser, transferDto.Amount);
            if (ret)
            {
                return Results.Ok("Token transferred");
            }
            else
            {
                return Results.Ok("Token not transferred");
            }
        }
    }
}
