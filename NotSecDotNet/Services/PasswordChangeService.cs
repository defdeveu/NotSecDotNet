using Microsoft.AspNetCore.Mvc;
using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.Model;

namespace NotSecDotNet.Services
{
    
    public class PasswordChangeService
    {
        MovieDbContext movieDbContext;
        public PasswordChangeService(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        public String ChangePassword(ChangePasswordDto pwdChange)
        {
            try
            {
                User usr = movieDbContext.Users.Single<User>(u => u.Name == pwdChange.user);
                if (usr.Password == pwdChange.oldPassword)
                {
                    RemotePasswrodChangeService remotePasswrodChangeService = new RemotePasswrodChangeService(movieDbContext);
                    String pwdChangeXml = createXml(pwdChange);
                    return remotePasswrodChangeService.ChangePassword(pwdChangeXml);
                }
                return "Old password not correct";

            }
            catch (Exception e)
            {
                return "No such user";
            }
        }

        public String createXml(ChangePasswordDto changePasswordDto)
        {
            return $"<user><pwd>{changePasswordDto.newPassword}</pwd><userName>{changePasswordDto.user}</userName></user>";
        }
    }
}
