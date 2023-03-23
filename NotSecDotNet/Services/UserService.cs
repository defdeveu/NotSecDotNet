using Microsoft.EntityFrameworkCore;
using NotSecDotNet.Data;
using NotSecDotNet.Model;

namespace NotSecDotNet.Services
{
   
    public class UserService
    {
        private readonly MovieDbContext movieDbContext;

        public UserService(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public User? FindUserByName(String userName)
        {
            try
            {
                User user = movieDbContext.Users.Single(u => u.Name == userName);
                return user;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
    }
}
