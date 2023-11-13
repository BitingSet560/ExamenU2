using System;
using System.Collections.Generic;

namespace ExamenLibreria.Models;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book>? Books { get; set; } = new List<Book>();
}
