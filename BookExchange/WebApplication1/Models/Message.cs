using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Message
{
    public int Idmessage { get; set; }

    public string? MessageText { get; set; }

    public int? UserId { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual User? User { get; set; }
}
