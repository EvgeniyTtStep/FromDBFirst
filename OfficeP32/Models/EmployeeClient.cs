using System;
using System.Collections.Generic;

namespace OfficeP32.Models;

public partial class EmployeeClient
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
