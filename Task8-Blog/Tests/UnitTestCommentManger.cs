using Xunit;
using Task8_Blog.Models;
using Tests;
using System.Collections.Generic;
using System.Linq;

namespace Tests;

public class UnitTestCommentManager
{
    private readonly BlogContext _context;
    private readonly CommentManager _commentManager;
    private readonly PostManager _postManager;


    public UnitTestCommentManager()
    {
        _context = ContextGenerator.GenerateContext();
        _commentManager = new CommentManager(_context);
        _postManager = new PostManager(_context);

    }

    [Fact]
    public void CreateComment_ShouldCreateComment()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        var comment = new Comment
        {
            Postid = newPost.Postid, 
            Text = "Comment Text 1"
        };

        var newComment = _commentManager.CreateComment(comment);

        Assert.NotNull(newComment);
        Assert.Equal(comment.Postid, newComment.Postid);
        Assert.Equal(comment.Text, newComment.Text);

        _commentManager.DeleteComment(newComment.Commentid);
        _postManager.DeletePost(newPost.Postid);
    }

    [Fact]
    public void GetCommentById_ShouldReturnComment()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        var comment = new Comment
        {
            Postid = newPost.Postid, 
            Text = "Comment Text 1"
        };

        var retComment = _commentManager.CreateComment(comment);

        Assert.NotNull(retComment);
        Assert.Equal(comment.Postid, retComment.Postid);
        Assert.Equal(comment.Text, retComment.Text);

        _commentManager.DeleteComment(retComment.Commentid);
        _postManager.DeletePost(newPost.Postid);
    }

    [Fact]
    public void GetCommentsByPostId_ShouldReturnCommentsForPost()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        var postId = newPost.Postid; 
        var comments = new List<Comment>
        {
            new Comment { Postid = postId, Text = "Comment 1" },
            new Comment { Postid = postId, Text = "Comment 2" },
            new Comment { Postid = postId, Text = "Comment 3" }
        };

        foreach (var comment in comments)
        {
            _commentManager.CreateComment(comment);
        }

        var commentsForPost = _commentManager.GetCommentsByPostId(postId).ToList();

        Assert.NotNull(commentsForPost);
        Assert.Equal(comments.Count, commentsForPost.Count);

        foreach (var comment in commentsForPost)
        {
            _commentManager.DeleteComment(comment.Commentid);
        }
        _postManager.DeletePost(newPost.Postid);
    }

    [Fact]
    public void UpdateComment_ShouldUpdateComment()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        var comment = new Comment
        {
            Postid = newPost.Postid, 
            Text = "Comment Text A"
        };

        comment = _commentManager.CreateComment(comment);

        comment.Text = "Comment Text B";
        _commentManager.UpdateComment(comment);

        var updatedComment = _commentManager.GetCommentById(comment.Commentid);

        Assert.NotNull(updatedComment);
        Assert.Equal("Comment Text B", updatedComment.Text);

        _commentManager.DeleteComment(comment.Commentid);
        _postManager.DeletePost(newPost.Postid);
    }

    [Fact]
    public void DeleteComment_ShouldDeleteComment()
    {
        var post = new Post{ Title = "Post Title A", Content = "Post Content 1" };
        var newPost = _postManager.CreatePost(post);
        var comment = new Comment
        {
            Postid = newPost.Postid, 
            Text = "Comment Text"
        };

        _commentManager.CreateComment(comment);

        _commentManager.DeleteComment(comment.Commentid);

        var deletedComment = _context.Comments.Find(comment.Commentid);

        Assert.Null(deletedComment);
        _postManager.DeletePost(newPost.Postid);

    }
}

