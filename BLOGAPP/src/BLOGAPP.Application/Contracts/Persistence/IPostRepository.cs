﻿using BLOGAPP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Contracts.Persistence;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetPostsWithDetails();
}

