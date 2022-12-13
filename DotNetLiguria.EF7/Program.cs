using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF7;

internal class Program
{
    static void Main(string[] args)
    {
        using var db = new MovieContext();

        AddMovie(db);
        //GetAllMovies(db);
        //ExecuteUpdate(db);
        //ExecuteDelete(db);
    }

    /// <summary>
    /// Get all movies
    /// </summary>
    /// <param name="db"></param>
    static void GetAllMovies(MovieContext db)
    {
        // Get all movies
        var movies = db.Movies.ToList();
        foreach (var movie in movies)
            Console.WriteLine(movie.Title);
    }

    /// <summary>
    /// Add a movie
    /// </summary>
    /// <param name="db"></param>
    static void AddMovie(MovieContext db)
    {
        // Insert a Movie
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
    /// Bulk delete
    /// </summary>
    /// <param name="db"></param>
    static void ExecuteDelete(MovieContext db)
    {
        db.Movies.Where(m => m.Id == 1).ExecuteDelete();
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