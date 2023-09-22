using Xunit;
using Microsoft.AspNetCore.Mvc;
using Task8_Blog.Models;
using Task8_Blog.Controllers;
using Moq;
using System.Collections.Generic;
namespace Tests;

public class UnitTestPostController
{
    private readonly Mock<PostManager> _postManager;
    private readonly PostController _postController;

    public UnitTestPostController()
    {
        _postManager = new Mock<PostManager>();
        _postController = new PostController(_postManager.Object);
    }

    [Fact]
    public void GetPostById_ReturnsOk()
    {
        var postId = 1;
        var post = new Post{ Title = "Title A", Content = "Content A" };
        _postManager.Setup(pm => pm.GetPostById(postId)).Returns(post);

        var response = _postController.GetPostById(postId);
        var okResult = Assert.IsType<OkObjectResult>(response);
        var model = Assert.IsType<Post>(okResult.Value);
        Assert.Equal(post, model);
    }

    [Fact]
    public void CreatePost_ReturnsCreatedAtAction()
    {
        var newPost = new Post { Title = "Title A", Content = "Content A" };
        _postManager.Setup(pm => pm.CreatePost(newPost)).Returns(newPost);

        var result = _postController.CreatePost(newPost);

        var createdType = Assert.IsType<CreatedAtActionResult>(result);
        var model = Assert.IsType<Post>(createdType.Value);
        Assert.Equal(newPost, model);
        Assert.Equal(nameof(PostController.GetPostById), createdType.ActionName);
    }


    [Fact]
    public void UpdatePost_ReturnsNoContent()
    {
        var postId = 1;
        var post = new Post { Title = "Title A", Content = "Content A" };
        var updatedPost = new Post { Title = "Title B", Content = "Content B" };
        _postManager.Setup(pm => pm.GetPostById(postId)).Returns(post);

        var result = _postController.UpdatePost(postId, updatedPost);

        Assert.IsType<NoContentResult>(result);
        Assert.Equal(updatedPost.Title, post.Title);
        Assert.Equal(updatedPost.Content, post.Content);
    }


    [Fact]
    public void DeletePost_ReturnsNoContent()
    {
        var postId = 1;
        _postManager.Setup(pm => pm.GetPostById(postId)).Returns(new Post());
        var result = _postController.DeletePost(postId);
        Assert.IsType<NoContentResult>(result);
    }

}
