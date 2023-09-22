using System;
using Task8_Blog;
using Task8_Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public static class ContextGenerator
{
    public static BlogContext GenerateContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
        optionsBuilder.UseInMemoryDatabase("blogs"); 

        var dbContext = new BlogContext(optionsBuilder.Options);
        return dbContext;
    }
}