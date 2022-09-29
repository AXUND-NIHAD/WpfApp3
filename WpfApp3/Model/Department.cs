using System;
using System.Collections.Generic;

namespace WpfApp3.Model;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
