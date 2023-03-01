using NotSecDotNet.model;
using NotSecDotNet.Model;

namespace NotSecDotNet.Data
{
    public  class DBInitializer: IHostedService
    {
        public  void Initialize(MovieDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;
            }
            var Yoda = new User
            {
                EmailAddress = "youda@jeditemple.org",
                Name = "Yoda",
                Sex = "m",
                Password = "NoSecretsATrueJediHas",
                Motto = "I don't know how old I am",
                WebPageUrl = "http://www.starwars.com/databank/yoda"
               
            };

            context.AddRange(Yoda);

            var Vader = new User
            {
                EmailAddress = "vader@jeditemple.org",
                Name = "Darth Vader",
                Sex = "m",
                Password = "IamYourFather",
                Motto = "I see a red door and I want it paint it back",
                WebPageUrl = "http://www.starwars.com/databank/vader"
               
            };

            context.AddRange(Vader);
            
            var Leia = new User
            {
                EmailAddress = "leia@jeditemple.org",
                Name = "Princess Leia",
                Sex = "f",
                Password = "Hansword123",
                Motto = "I wish I have choosen the Wookie instead",
                WebPageUrl = "http://www.starwars.com/databank/leia"
               
            };

            context.AddRange(Leia);

            var sw1 = new Movie
            {
                Title = "Star Wars - A new hope",
                Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                Genre = "sci-fi"
            };

            context.AddRange(sw1);

            var sw2 = new Movie
            {
                Title = "Star Wars - The Empire Strikes Back",
                Description = "After the Rebels are overpowered by the Empire, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.",
                Genre = "sci-fi"
            };

            context.AddRange(sw2);
            
            var sw3 = new Movie
            {
                Title = "Star Wars - The Return of the Jedi",
                Description = "After rescuing Han Solo from Jabba the Hutt, the Rebels attempt to destroy the second Death Star, while Luke struggles to help Darth Vader back from the dark side.",
                Genre = "sci-fi"
            };

            context.AddRange(sw3);

            context.SaveChanges();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
