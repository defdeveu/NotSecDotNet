using Microsoft.EntityFrameworkCore;
using NotSecDotNet.model;
using NotSecDotNet.Model;

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



    }
}
