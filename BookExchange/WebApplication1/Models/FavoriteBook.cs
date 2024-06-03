using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class FavoriteBook
{
    public int IdfavouriteBooks { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
