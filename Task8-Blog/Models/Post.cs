using System;
using System.Collections.Generic;

namespace Task8_Blog.Models;

public class Post
{
    public int Postid { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Createdat { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}

public  class PostSummary{
    public int Postid { get; set; }
    
    public string Title { get; set; } = null!;

    public string Summary { get; set; } = null!;
}

