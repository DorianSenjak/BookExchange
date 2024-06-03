using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Account
{
    public int Idaccount { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
