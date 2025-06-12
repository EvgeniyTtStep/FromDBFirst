using System;
using System.Collections.Generic;

namespace OfficeP32.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string NameEmployee { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? PositionId { get; set; }

    public int? SkillsId { get; set; }

    public virtual ICollection<EmployeeClient> EmployeeClients { get; set; } = new List<EmployeeClient>();

    public virtual Position? Position { get; set; }

    public virtual Skill? Skills { get; set; }
}
