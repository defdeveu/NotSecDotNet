using Microsoft.AspNetCore.Mvc;
using NotSecDotNet.Data;
using NotSecDotNet.model;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace NotSecDotNet.Controllers
{
    [ApiController]
    public class MovieController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private MovieDbContext _dbContext;


        public MovieController(ILogger<WeatherForecastController> logger, MovieDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [Route("movie")]
        [HttpGet]
        public IEnumerable<Movie> GetMovies(
            [FromQuery] string? title, 
            [FromQuery] string? description, 
            [FromQuery] string? genre, 
            [FromQuery] int? id)
        {
            IQueryable<Movie> query = _dbContext.Movies;
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
            return _dbContext.Movies.FromSqlRaw(sb.ToString()).ToList();
        }
    }
}