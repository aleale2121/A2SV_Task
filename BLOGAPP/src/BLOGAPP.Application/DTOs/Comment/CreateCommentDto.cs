using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentCreateDTO : CommentCommonDTO
{
    public string CreatedBy { get; set; }

}

