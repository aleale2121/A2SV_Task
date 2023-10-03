using System;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IPostRepository PostRepository { get; }
    ICommentRepository CommentRepository { get; }
    Task Save();
}

