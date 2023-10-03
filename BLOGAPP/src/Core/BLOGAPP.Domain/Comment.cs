using System;
using System.Collections.Generic;
using BLOGAPP.Domain.Common;

namespace BLOGAPP.Domain;

public class Comment: BaseDomainEntity
{

    public int Postid { get; set; }

    public string Text { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
