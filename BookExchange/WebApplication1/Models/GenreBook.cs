using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class GenreBook
{
    public int IdgenreBook { get; set; }

    public int? BookId { get; set; }

    public int? GenreId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Genre? Genre { get; set; }
}
