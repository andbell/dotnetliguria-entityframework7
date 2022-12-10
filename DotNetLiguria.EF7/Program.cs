namespace DotNetLiguria.EF7;

internal class Program
{
    static void Main(string[] args)
    {
        GetAllMovies();   
    }

    static void GetAllMovies()
    {
        using var db = new MovieContext();
        var movies = db.Movies.ToList();
        foreach (var movie in movies)
            Console.WriteLine(movie.Title);
    }
}