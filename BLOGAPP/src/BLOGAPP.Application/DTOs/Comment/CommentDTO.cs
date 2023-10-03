using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentDTO: BaseDto,ICommentDTO
{
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
}
