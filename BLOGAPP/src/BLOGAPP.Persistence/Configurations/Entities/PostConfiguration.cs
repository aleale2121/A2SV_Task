using BLOGAPP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Persistence.Configurations.Entities;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
          builder.HasData(
                new Post
                {
                    Id = 1,
                    Title = "Software", 
                    Content = "Software Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin"
                },
                new Post
                {
                    Id = 2,
                    Title = "Backend",
                    Content = "Backend Server Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin"

                },
                new Post
                {
                    Id = 3,
                    Title = "Web",
                    Content = "Web App Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin"

                },
                new Post {
                    Id = 4,
                    Title = "Mobile", 
                    Content = "Mobile App Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin"
                }
            );
    }
}

