using System;
using System.Collections.Generic;

namespace OfficeP32.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<EmployeeClient> EmployeeClients { get; set; } = new List<EmployeeClient>();
}
