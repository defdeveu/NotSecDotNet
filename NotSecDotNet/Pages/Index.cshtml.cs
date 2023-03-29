using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotSecDotNet.Controllers;
using NotSecDotNet.model;
using NotSecDotNet.Services;

namespace NotSecDotNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MovieService movieService;

        public List<Movie> Movies { get; set; }

        [BindProperty]
        public string? Title { get; set; }
        [BindProperty]
        public string? Desc { get; set; }
        [BindProperty]
        public string? Genre { get; set; }
        [BindProperty]
        public int? Id { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MovieService ms)
        {
            _logger = logger;
            this.movieService = ms;

        }

        public void OnGet()
        {
            
            Movies = new List<Movie>();
            IEnumerable<Movie> enumerable = movieService.GetMovies(null, null, null, null);
            Movies.AddRange(enumerable);

        }


        public void OnPost()
        {
            Movies = new List<Movie>();
            IEnumerable<Movie> enumerable = movieService.GetMovies(Title, Desc, Genre, Id);
            Movies.AddRange(enumerable);
        }
    }
}