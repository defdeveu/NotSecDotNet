using Microsoft.EntityFrameworkCore;
using NotSecDotNet.model;
using NotSecDotNet.Model;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace NotSecDotNet.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MovieObject> MovieObjects { get; set; } = null!;

        public DbSet<TokenAccount> TokenAccounts { get; set; } = null!;
        public DbSet<TokenFlow> TokenFlows { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            /*optionsBuilder.LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                EmailAddress = "yoda@jeditemple.org",
                Name = "Yoda",
                Sex = "m",
                Password = "NoSecretsATrueJediHas",
                Motto = "I don't know how old I am",
                WebPageUrl = "http://www.starwars.com/databank/yoda"

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                EmailAddress = "vader@jeditemple.org",
                Name = "Darth Vader",
                Sex = "m",
                Password = "IamYourFather",
                Motto = "I see a red door and I want it paint it back",
                WebPageUrl = "http://www.starwars.com/databank/vader"

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                EmailAddress = "leia@jeditemple.org",
                Name = "Princess Leia",
                Sex = "f",
                Password = "Hansword123",
                Motto = "I wish I have choosen the Wookie instead",
                WebPageUrl = "http://www.starwars.com/databank/leia"

            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Star Wars - A new hope",
                Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                Genre = "sci-fi"
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "Star Wars - The Empire Strikes Back",
                Description = "After the Rebels are overpowered by the Empire, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.",
                Genre = "sci-fi"
            });


            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "Star Wars - The Return of the Jedi",
                Description = "After rescuing Han Solo from Jabba the Hutt, the Rebels attempt to destroy the second Death Star, while Luke struggles to help Darth Vader back from the dark side.",
                Genre = "sci-fi"
            });




            modelBuilder.Entity<MovieObject>().HasData(new MovieObject
            {
                Id = 1,
                Name = "Princess Lea figure",
                Description = "A beautiful, handpainted lively model of the young Lea.",
                Price = 3500
            });


            modelBuilder.Entity<MovieObject>().HasData(new MovieObject
            {
                Id = 2,
                Name = "Yoda figure",
                Description = "A beautiful, handpainted exclusvely-green model of Yoda.",
                Price = 3600
            });


            modelBuilder.Entity<MovieObject>().HasData(new MovieObject
            {
                Id = 3,
                Name = "Full Darth Veder Armor",
                Description = "A full-sized authentic costume of Darth-veder with boots, trousers, robe, mask and a beutifully cracted light-sword",
                Price = 214750
            });

            


            modelBuilder.Entity<TokenAccount>().HasData(new TokenAccount
            {
                Id = 1,
                Amount = 100,
                UserId = 1
            });   
            
            modelBuilder.Entity<TokenAccount>().HasData(new TokenAccount
            {
                Id = 2,
                Amount = 100,
                UserId = 2
            });

            modelBuilder.Entity<TokenAccount>().HasData(new TokenAccount
            {
                Id = 3,
                Amount = 100,
                UserId = 3
            });



        }
    }
}
