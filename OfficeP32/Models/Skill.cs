using System;
using System.Collections.Generic;

namespace OfficeP32.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string NameSkill { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
