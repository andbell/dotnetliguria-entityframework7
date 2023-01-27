using DotNetLiguria.EF7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF7.WebApi.Controllers;

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
    public async Task<ActionResult<Movie>> AddMovie(Movie movie)
    {
        _context.Add(movie);
        await _context.SaveChangesAsync();
        return Ok(movie);
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetAllMovies()
    {
        var movies = await _context.Movies
            .Select(x => new { x.Title, x.Info.Year, x.Id })
            .TagWith("Use robust plan")
            .ToListAsync();
        return Ok(movies);
    }

    [HttpGet("find")]
    public async Task<ActionResult<List<Movie>>> FindMovies([FromQuery] string? title, [FromQuery] string? actor, [FromQuery] int? year, [FromQuery] int? minDuration)
    {
        var query = _context.Movies.AsQueryable();

        if (title is not null)
            query = query.Where(x => x.Title.Contains(title));

        if (minDuration is not null)
            query = query.Where(x => x.Info.Duration >= minDuration);

        if (year.HasValue)
            query = query.Where(x => x.Info.Year == year.Value);

        // THIS THROW AN EXCEPTION AT RUNTIME
        if (actor is not null)
            query = query.Where(x => x.Cast.Actors.Any(a => a.FullName.Contains(actor)));

        var movies = await query.ToListAsync();
        return Ok(movies);
    }

    [HttpGet("{movieId:int}")]
    public async Task<ActionResult<Movie>> GetMovieById(int movieId)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);

        if (movie is null)
            return NotFound();

        //Console.WriteLine($"Movie '{movie.Title}' was retrieved at '{movie.Retrieved.ToLocalTime()}'");
        return Ok(movie);
    }

    [HttpDelete]
    public async Task<ActionResult<List<Movie>>> DeleteMovie(int movieId)
    {
        await _context.Movies.Where(m => m.Id == movieId).ExecuteDeleteAsync();
        return NoContent();
    }

    [HttpPut("bulk")]
    public async Task<ActionResult> UpdateMovieBulk()
    {
        await _context.Movies.Where(m => m.Info.Year == 2020)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.Title, c => $"{c.Title} (2020)"));
        return NoContent();
    }

    [HttpPut("{movieId:int}")]
    public async Task<ActionResult<Movie>> UpdateMovie(int movieId)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == movieId);

        if (movie is null)
            return NotFound();

        movie.Info.Duration = 100;
        movie.Cast.Actors.Add(new Person { FullName = "Andrea Belloni" });

        await _context.SaveChangesAsync();

        return Ok();
    }
}