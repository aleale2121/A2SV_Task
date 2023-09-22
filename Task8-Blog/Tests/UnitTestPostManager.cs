using Xunit;
using Task8_Blog.Models;
using Tests;
namespace Tests;

public class UnitTestPostManager
{
    private readonly BlogContext _context;
    private readonly PostManager _postManager;

    public UnitTestPostManager()
    {
        _context = ContextGenerator.GenerateContext();
        _postManager = new PostManager(_context);
    }

    [Fact]
    public void CreatePost_ShouldCreatePost()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        Assert.NotNull(newPost);
        Assert.Equal(newPost.Title, newPost.Title);
         _postManager.DeletePost(newPost.Postid);
    }

    [Fact]
    public void GetPostById_ShouldReturnPost()
    {
        var post = new Post{ 
            Title = "Title 1", 
            Content = "Content 1" };
        post=_postManager.CreatePost(post);

        var retPost = _postManager.GetPostById(post.Postid);

        Assert.NotNull(retPost);
        Assert.Equal(post.Title, retPost.Title);
        Assert.Equal(post.Content, retPost.Content);
        Assert.NotNull(retPost.Comments);
        _postManager.DeletePost(retPost.Postid);
    }

    [Fact]
    public void GetAllPosts_ShouldGetAllPost()
    {
        var allPosts = _postManager.GetAllPosts();
        Assert.NotNull(allPosts);
        Assert.Equal(_context.Posts.Count(), allPosts.Count);
    }

    [Fact]
    public void UpdatePost_ShouldUpdatePost()
    {
        var post = new Post { Title = "Title A", Content = "Content A" };
        post = _postManager.CreatePost(post);

        post.Title = "Title B";
        _postManager.UpdatePost(post);
        var updatedPost = _postManager.GetPostById(post.Postid);

        Assert.NotNull(updatedPost);
        Assert.Equal("Title B", updatedPost.Title);
        _postManager.DeletePost(post.Postid);
    }

    [Fact]
    public void DeletePost_ShouldDeletePost()
    {
        var post = new Post { Title = "Title", Content = "Content" };
        _postManager.CreatePost(post);

        _postManager.DeletePost(post.Postid);
        var deleted = _context.Posts.Find(post.Postid);
        Assert.Null(deleted);
    }
}

