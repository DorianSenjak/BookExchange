using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class BookReview
{
    public int IdbookReview { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
