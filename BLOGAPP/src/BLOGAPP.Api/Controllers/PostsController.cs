using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Features.Posts.Requests.Commands;
using BLOGAPP.Application.Features.Posts.Requests.Queries;
using BLOGAPP.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BLOGAPP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        this._httpContextAccessor = httpContextAccessor;
    }

    // GET: api/<PostsController>
    [HttpGet]
    public async Task<ActionResult<List<PostDTO>>> Get()
    {
        System.Console.WriteLine("HERE");
        var posts = await _mediator.Send(new GetPostListRequest());
        return Ok(posts);
    }

    // GET: api/<PostsController>/detailed
    // [HttpGet("detailed")]
    // public async Task<ActionResult<List<PostDTO>>> GetPostsWithDetails()
    // {
    //     var posts = await _mediator.Send(new GetPostListRequest());
    //     return Ok(posts);
    // }

    // GET api/<PostsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> Get(int id)
    {
        var post = await _mediator.Send(new GetPostDetailRequest { Id = id });
        return Ok(post);
    }

    // POST api/<PostsController>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    // [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PostCreateDTO post)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var command = new CreatePostCommand { PostDto = post };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<PostsController>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    // [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> Put([FromBody] PostUpdateDTO post)
    {
        var command = new UpdatePostCommand { PostDto = post };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<PostsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    // [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePostCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
