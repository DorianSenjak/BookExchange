using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Book
{
    public int Idbook { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? CoverPageImage { get; set; }

    public string? Publisher { get; set; }

    public int? Pages { get; set; }

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; } = new List<FavoriteBook>();

    public virtual ICollection<GenreBook> GenreBooks { get; set; } = new List<GenreBook>();
}
