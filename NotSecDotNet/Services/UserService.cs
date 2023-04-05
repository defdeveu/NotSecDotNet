using Microsoft.EntityFrameworkCore;
using NotSecDotNet.Controllers;
using NotSecDotNet.Data;
using NotSecDotNet.Model;

namespace NotSecDotNet.Services
{
   
    public class UserService
    {
        private readonly MovieDbContext movieDbContext;
        private readonly ILogger<UserService> logger;

        public UserService(MovieDbContext movieDbContext, ILogger<UserService> logger)
        {
            this.movieDbContext = movieDbContext;
            this.logger = logger;
        }

        public User? FindUserByName(String userName)
        {
            try
            {
                User user = movieDbContext.Users.Single(u => u.Name == userName);
                TokenAccount t = user.token;
                return user;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public TokenAccount FindTokenAccount(int userId)
        {
            TokenAccount account = movieDbContext.TokenAccounts.Single(ta => ta.Id == userId);
            return account;
        }

        public Boolean TransferToken(int fromUser, String toUser, int amount)
        {
            TokenAccount fromAccount = movieDbContext.TokenAccounts.Single(ta => ta.Id == fromUser);
            User? destUser = FindUserByName(toUser);
            if(destUser == null)
            {
                return false;
            }
            logger.LogInformation("From account's balance is: {balance}", fromAccount.Amount);
            Thread.Sleep(10_000);
            TokenAccount toAccount = movieDbContext.TokenAccounts.Single(ta => ta.Id == destUser.Id);
            if(fromAccount.Amount > amount)
            {
                fromAccount.Amount = fromAccount.Amount - amount;
                toAccount.Amount = toAccount.Amount + amount;
                TokenFlow tokenFlow = new TokenFlow();
                tokenFlow.FromAccount = fromAccount;
                tokenFlow.ToAccount = toAccount;
                tokenFlow.Amount = amount;
                movieDbContext.Add(tokenFlow);
                movieDbContext.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
