using Microsoft.AspNetCore.Mvc;
using Task8_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task8_Blog.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentController : ControllerBase{

    private readonly CommentManager _commentManager;
    public CommentController(CommentManager commentManager){
        _commentManager = commentManager;
    }

    [HttpGet("{id}")]
    public IActionResult GetCommentById(int commentId)
    {
        var comment = _commentManager.GetCommentById(commentId);
        if (comment == null)
        {
            return NotFound(); 
        }
        return Ok(comment);
    }

    [HttpPost]
    public IActionResult CreateComment([FromBody] Comment comment)
    {
        var newComment = _commentManager.CreateComment(comment);
        return CreatedAtAction(nameof(GetCommentById), new { id = newComment.Commentid }, newComment);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateComment(int commentId, [FromBody] Comment comment)
    {
        var currComment = _commentManager.GetCommentById(commentId);
        if (currComment == null)
        {
            return NotFound();
        }

        currComment.Text = comment.Text;
        _commentManager.UpdateComment(currComment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComment(int commentId)
    {
        var currComment = _commentManager.GetCommentById(commentId);
        if (currComment == null){
            return NotFound();
        }

        _commentManager.DeleteComment(commentId);
        return NoContent();
    }
}
