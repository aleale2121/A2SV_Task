using System;
using System.Collections.Generic;
using BLOGAPP.Domain.Common;

namespace BLOGAPP.Domain;

public class Post: BaseDomainEntity
{
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}

