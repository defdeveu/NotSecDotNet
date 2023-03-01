using Microsoft.AspNetCore.Mvc;
using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.model;
using NotSecDotNet.Model;
using NotSecDotNet.Services;

namespace NotSecDotNet.Controllers
{
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
    }
}
