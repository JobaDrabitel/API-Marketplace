using System;
using System.Collections.Generic;

namespace API_Marketplace_.net_7_v1.Models1;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
