using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF7;

internal class Program
{
    static void Main(string[] args)
    {
        using var db = new MovieContext();
       
        GetAllMovies(db);

        //AddMovie(db);
        AddSerieTv(db);

        //ExecuteUpdate(db);
        //ExecuteDelete(db, 2);

        Console.ReadLine();
    }

    /// <summary>
    /// Get all movies
    /// </summary>
    /// <param name="db"></param>
    static void GetAllMovies(MovieContext db)
    {
        // Get all movies
        var movies = db.Movies.Select(m => new { m.Id,  m.Title, m.Year }).ToList();
        
        foreach (var movie in movies)
            Console.WriteLine($"{movie.Title} ({movie.Year}) - ID: {movie.Id}");
    }

    /// <summary>
    /// Add a movie
    /// </summary>
    /// <param name="db"></param>
    static void AddMovie(MovieContext db)
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
        db.Add(newMovie);
        db.SaveChanges();
    }

    /// <summary>
    /// Insert a SerieTV
    /// </summary>
    /// <param name="db"></param>
    static void AddSerieTv(MovieContext db)
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
        db.Add(newSerieTv);
        db.SaveChanges();
    }
    
    /// <summary>
    /// Bulk delete
    /// </summary>
    /// <param name="db"></param>
    static void ExecuteDelete(MovieContext db, int movieId)
    {
        db.Movies.Where(m => m.Id == movieId).ExecuteDelete();
    }

    /// <summary>
    /// Bulk update
    /// </summary>
    /// <param name="db"></param>
    static void ExecuteUpdate(MovieContext db)
    {
        db.Movies.Where(m => m.Year == 2020)
            .ExecuteUpdate(u => u.SetProperty(p => p.Title, c => $"{c.Title} (2020)"));
    }
}