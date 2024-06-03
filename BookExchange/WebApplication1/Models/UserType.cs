using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class UserType
{
    public int IduserType { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
