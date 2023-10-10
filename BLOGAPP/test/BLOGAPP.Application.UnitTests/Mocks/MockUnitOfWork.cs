using BLOGAPP.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Application.UnitTests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockPostRepo = MockPostRepository.GetPostRepository();

        mockUow.Setup(r => r.PostRepository).Returns(mockPostRepo.Object);

        return mockUow;
    }
}

