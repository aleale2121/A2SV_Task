using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentCreateDTO : ICommentDTO
{
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}

