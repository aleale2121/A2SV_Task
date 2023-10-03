using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentUpdateDTO : BaseDto, ICommentDTO
{
    public string UpdatedBy { get; set; }
}
