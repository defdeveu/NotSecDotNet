using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotSecDotNet.Data;
using NotSecDotNet.model;
using System.Text;

namespace NotSecDotNet.Services
{
    public class MovieService
    {
        private readonly MovieDbContext movieDbContext;

        public MovieService(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public IEnumerable<Movie> GetMovies(
            string? title,
            string? description,
            string? genre,
            int? id)
        {
            IQueryable<Movie> query = movieDbContext.Movies;
            StringBuilder sb = new StringBuilder("select * from Movies where 1=1");
            if (!String.IsNullOrEmpty(title))
            {
                sb.Append($" and Title like '%{title}%'");
            }
            if (!String.IsNullOrEmpty(description))
            {
                sb.Append($" and Description like '%{description}%'");
            }
            if (!String.IsNullOrEmpty(genre))
            {
                sb.Append($" and Genre = '{genre}'");
            }
            if (id != null)
            {
                sb.Append($" and Id = {id}");
            }
            return movieDbContext.Movies.FromSqlRaw(sb.ToString()).ToList();
        }
    }
}
