using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public class PostUpdateDTO :BaseDto,PostDTO
{
    public string UpdatedBy { get; set; }
}

