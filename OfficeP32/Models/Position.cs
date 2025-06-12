using System;
using System.Collections.Generic;

namespace OfficeP32.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string NamePosition { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
