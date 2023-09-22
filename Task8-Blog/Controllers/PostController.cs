using Microsoft.AspNetCore.Mvc;
using Task8_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task8_Blog.Controllers;


[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase{

    private readonly PostManager _postManager;
    public PostController(PostManager postManager){
        _postManager = postManager;
    }

    [HttpGet]
    public IActionResult GetPosts(){
        var posts = _postManager.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetPostById(int id){
        var postDetails = _postManager.GetPostById(id);
        if (postDetails == null){
            return NotFound();
        }
        return Ok(postDetails);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post){
        var newPost = _postManager.CreatePost(post);
        return CreatedAtAction(nameof(GetPostById), new { id = newPost.Postid }, newPost);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(int id, [FromBody] Post post){
        var currPost = _postManager.GetPostById(id);
        if (currPost == null){
            return NotFound();
        }
        currPost.Title = post.Title;
        currPost.Content = post.Content;
        _postManager.UpdatePost(currPost);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int id){
        var post = _postManager.GetPostById(id);
        if (post == null){
            return NotFound();
        }
        _postManager.DeletePost(id);
        return NoContent();
    }
}
