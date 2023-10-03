using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public class PostDTO : BaseDto, IPostDTO
{
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public List<CommentDTO> Comments {get;}
}

