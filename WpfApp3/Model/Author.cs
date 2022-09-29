using System;
using System.Collections.Generic;

namespace WpfApp3.Model;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
