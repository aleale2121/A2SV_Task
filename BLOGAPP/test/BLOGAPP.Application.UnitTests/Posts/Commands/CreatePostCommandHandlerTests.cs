using AutoMapper;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Posts.Handlers.Commands;
using BLOGAPP.Application.Features.Posts.Handlers.Queries;
using BLOGAPP.Application.Features.Posts.Requests.Commands;
using BLOGAPP.Application.Features.Posts.Requests.Queries;
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

namespace BLOGAPP.Application.UnitTests.Posts.Commands;

public class CreatePostCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly PostCreateDTO _postDto;
    private readonly CreatePostCommandHandler _handler;

    public CreatePostCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();
        
        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreatePostCommandHandler(_mockUow.Object, _mapper);

        _postDto = new  PostCreateDTO{
            Title = "Fullstack", 
            Content = "Fullstack Development",
            CreatedBy = "Admin"
        };
    }

    [Fact]
    public async Task Valid_Post_Added()
    {
        var result = await _handler.Handle(new CreatePostCommand() { PostDto = _postDto }, CancellationToken.None);

        var posts = await _mockUow.Object.PostRepository.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();

        posts.Count.ShouldBe(5);
    }

    [Fact]
    public async Task InValid_Post_Added()
    {
        _postDto.CreatedBy = "";

        var result = await _handler.Handle(new CreatePostCommand() { PostDto = _postDto }, CancellationToken.None);

        var posts = await _mockUow.Object.PostRepository.GetAll();
        
        posts.Count.ShouldBe(4);

        result.ShouldBeOfType<BaseCommandResponse>();
        
    }
}
