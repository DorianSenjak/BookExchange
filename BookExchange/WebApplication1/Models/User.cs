using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public int? UserTypeId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; } = new List<FavoriteBook>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual UserType? UserType { get; set; }
}
