using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class UserGroup
{
    public int IduserGroup { get; set; }

    public int? UserId { get; set; }

    public int? GroupId { get; set; }
}
