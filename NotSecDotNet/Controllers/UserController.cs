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
        public UserController(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
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
                UserService userService = new UserService(movieDbContext);
                User u = userService.FindUserByName(userName);
                if(u != null)
                {
                    return Results.Ok(u);
                }
            }
            HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Results.Unauthorized();
        }
    }
}
