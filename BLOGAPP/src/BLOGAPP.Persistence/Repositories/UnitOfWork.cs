
using AutoMapper;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Application.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLOGAPP.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly BLOGAPPDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IPostRepository _postRepository;
    private ICommentRepository _commentRepository;


    public UnitOfWork(BLOGAPPDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    public IPostRepository PostRepository => 
        _postRepository ??= new PostRepository(_context);

    public ICommentRepository CommentRepository => 
        _commentRepository ??= new CommentRepository(_context);
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
        var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        await _context.SaveChangesAsync(username);
    }
}

