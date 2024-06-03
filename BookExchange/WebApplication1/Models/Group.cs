using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Group
{
    public int Idgroup { get; set; }

    public string? Title { get; set; }

    public int? MaximumUsers { get; set; }

    public int? GroupTypeId { get; set; }

    public virtual GroupType? GroupType { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
