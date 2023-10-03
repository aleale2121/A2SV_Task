using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Comment;

public interface CommentCommonDTO
{
    public int Postid {get; set;}
    public string Text { get; set; }
}
