﻿using DotNetLiguria.EF7.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLiguria.EF7.Models;

public class Movie : IHasRetrieved
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool SerieTV { get; set; }
    public string Abstract { get; set; }

    public Cast Cast { get; set; }
    public MovieInfo Info { get; set; }
    public Seasons Seasons { get; set; }

    [NotMapped]
    public DateTime Retrieved { get; set; }
}
