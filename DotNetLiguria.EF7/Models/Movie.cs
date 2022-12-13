namespace DotNetLiguria.EF7.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public bool SerieTV { get; set; }
    public string Abstract { get; set; }
    public List<Genre> Genres { get; set; }

    public Cast Cast { get; set; }
}
