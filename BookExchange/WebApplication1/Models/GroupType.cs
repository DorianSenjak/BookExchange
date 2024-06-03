using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class GroupType
{
    public int IdgroupType { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
