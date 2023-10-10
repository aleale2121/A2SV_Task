using AutoMapper;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Application.DTOs;

using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Features.Posts.Handlers.Queries;
using BLOGAPP.Application.Features.Posts.Requests.Queries;
using BLOGAPP.Application.Profiles;
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

namespace BLOGAPP.Application.UnitTests.Posts.Queries;

public class GetPostListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IPostRepository> _mockRepo;
    private readonly  GetPostListRequestHandler _handler;
    public GetPostListRequestHandlerTests()
    {
        _mockRepo = MockPostRepository.GetPostRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new GetPostListRequestHandler(_mockRepo.Object, _mapper);

        
    }

    [Fact]
    public async Task GetPostListTest()
    {

        // var result = await _handler.Handle(new GetPostListRequest(), CancellationToken.None);
        // System.Console.WriteLine(result.Count);
        // result.ShouldBeOfType<List<PostDTO>>();

        // result.Count.ShouldBe(4);
    }
}

