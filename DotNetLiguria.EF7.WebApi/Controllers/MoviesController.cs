using DotNetLiguria.EF7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF7.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost("movie")]
        public async Task<ActionResult<Movie>> AddMovie()
        {
            var newMovie = new Movie
            {
                Title = "Interstellar",
                Year = 2014,
                SerieTV = false,
                Abstract = "One of the best movie ever!",
                Cast = new Cast
                {
                    Actors = new List<Person>
                {
                    new Person { FullName = "Matthew McConaughey" },
                    new Person { FullName = "Anne Hathaway" },
                    new Person { FullName = "Jessica Chastain" },
                },
                    Directors = new List<Person>
                {
                    new Person { FullName = "Christopher Nolan" },
                }
                }
            };
            _context.Add(newMovie);
            await _context.SaveChangesAsync();
            
            return Ok(newMovie);
        }

        [HttpPost("serietv")]
        public async Task<ActionResult<Movie>> AddSerieTv()
        {
            var newSerieTv = new SerieTv
            {
                Title = "Dark",
                Year = 2018,
                SerieTV = true,
                Abstract = "One of the best serie TV ever!",
                Cast = new Cast
                {
                    Actors = new List<Person>
                {
                    new Person { FullName = "Louis Hofmann" },
                    new Person { FullName = "Maja Schöne" },
                    new Person { FullName = "Jördis Triebel" },
                },
                    Directors = new List<Person>
                {
                    new Person { FullName = "Baran bo Odar" },
                }
                },
                Seasons = new Seasons
                {
                    Episodes = new List<Episode>
                {
                    new Episode { Title = "Episode 1", Duration = 45, Number = 1, Season = 1 },
                    new Episode { Title = "Episode 2", Duration = 45, Number = 2, Season = 2 },
                }
                }
            };
            _context.Add(newSerieTv);
            await _context.SaveChangesAsync();

            return Ok(newSerieTv);
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await _context.Movies.Select(x => new {x.Id, x.Title, x.Year}).ToListAsync();
            return Ok(movies);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int movieId)
        {
            await _context.Movies.Where(m => m.Id == movieId).ExecuteDeleteAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie()
        {
            await _context.Movies.Where(m => m.Year == 2020).ExecuteUpdateAsync(u => u.SetProperty(p => p.Title, c => $"{c.Title} (2020)"));
            return NoContent();
        }
    }
}