using System;
using System.Collections.Generic;

namespace WpfApp3.Model;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
