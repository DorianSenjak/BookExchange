using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Genre
{
    public int Idgenre { get; set; }

    public string? GenreName { get; set; }

    public virtual ICollection<GenreBook> GenreBooks { get; set; } = new List<GenreBook>();
}
