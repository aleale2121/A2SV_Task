using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.Features.Comments.Requests.Commands;
using BLOGAPP.Application.Features.Comments.Requests.Queries;
using BLOGAPP.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BLOGAPP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CommentsController>
    [HttpGet]
    public async Task<ActionResult<List<CommentDTO>>> Get(bool isLoggedInUser = false)
    {
        var comments = await _mediator.Send(new GetPostCommentListRequest() {});
        return Ok(comments);
    }

    // GET api/<CommentsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDTO>> Get(int id)
    {
        var comment = await _mediator.Send(new GetCommentDetailRequest { Id = id });
        return Ok(comment);
    }

    // POST api/<CommentsController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CommentCreateDTO comment)
    {
        var command = new CreateCommentCommand { CommentDto = comment };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }



    // GET api/<CommentsController>/posts/5
    [HttpGet("posts/{id}")]
    public async Task<ActionResult> GetPostComments(int id)
    {
        var command = new GetPostCommentListRequest { PostId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<CommentsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCommentCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

