using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public class PostCreateDTO : IPostDTO
{
    public string CreatedBy { get; set; }
}

