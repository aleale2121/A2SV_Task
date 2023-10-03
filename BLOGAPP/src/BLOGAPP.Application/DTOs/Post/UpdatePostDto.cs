using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public class PostUpdateDTO :BaseDto,IPostDTO
{
    public string UpdatedBy { get; set; }
}

