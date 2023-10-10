using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Application.UnitTests.Mocks;
public static class MockPostRepository
{
    public static Mock<IPostRepository> GetPostRepository()
    {
        var posts = new List<Post>
        {
                new Post
                {
                    Id = 1,
                    Title = "Software",
                    Content = "Software Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin",
                    Comments =  new List<Comment> {}

                },
                new Post
                {
                    Id = 2,
                    Title = "Backend",
                    Content = "Backend Server Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin",
                    Comments =  new List<Comment> {}

                },
                new Post
                {
                    Id = 3,
                    Title = "Web",
                    Content = "Web App Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin",
                    Comments =  new List<Comment> {}

                },
                new Post {
                    Id = 4,
                    Title = "Mobile",
                    Content = "Mobile App Development",
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin",
                    Comments =  new List<Comment> {}
                }
        };

        var mockRepo = new Mock<IPostRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);
        mockRepo.Setup(r => r.GetPostsWithDetails()).ReturnsAsync(posts);


        mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) =>
        {
            posts.Add(post);
            return post;
        });


        return mockRepo;

    }
}

