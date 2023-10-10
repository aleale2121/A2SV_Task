using AutoMapper;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Posts.Handlers.Commands;
using BLOGAPP.Application.Features.Posts.Requests.Commands;
using BLOGAPP.Application.Profiles;
using BLOGAPP.Application.Responses;
using BLOGAPP.Application.UnitTests.Mocks;
using BLOGAPP.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLOGAPP.Application.UnitTests.Posts.Commands
{
    public class UpdatePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockUow;
        private readonly PostUpdateDTO _postDto;
        private readonly UpdatePostCommandHandler _handler;

        public UpdatePostCommandHandlerTests()
        {
            _mockUow = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdatePostCommandHandler(_mockUow.Object, _mapper);

            _postDto = new PostUpdateDTO
            {
                Id = 1,
                Title = "Updated Title",
                Content = "Updated Content",
                UpdatedBy = "Admin"
            };
        }

        [Fact]
        public async Task Valid_Post_Updated()
        {
            var result = await _handler.Handle(new UpdatePostCommand() { PostDto = _postDto }, CancellationToken.None);

            var posts = await _mockUow.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            posts.Count.ShouldBe(4);
           
        }

        [Fact]
        public async Task InValid_Post_Updated()
        {
            _postDto.Title = ""; 

            var result = await _handler.Handle(new UpdatePostCommand() { PostDto = _postDto }, CancellationToken.None);

            // result.Count.ShouldBe(6);
            result.ShouldBeOfType<BaseCommandResponse>();
            var posts = await _mockUow.Object.PostRepository.GetAll();


            posts[1].Title.ShouldNotBe("Updated Title");
            posts[1].Content.ShouldNotBe("Updated Content");
        }
    }
}
