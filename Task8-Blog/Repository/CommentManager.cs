using Task8_Blog.Models;

public class CommentManager
{
    private readonly BlogContext _context;

    public CommentManager(BlogContext context)
    {
        _context = context;
    }

    public Comment CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    public Comment GetCommentById(int id)
    {
        return _context.Comments.FirstOrDefault(com=> com.Commentid == id);
    }

    public IEnumerable<Comment> GetCommentsByPostId(int postId)
    {
        return _context.Comments.Where(c => c.Postid == postId);
    }

    public void UpdateComment(Comment comment){
        _context.Comments.Update(comment);
        _context.SaveChanges();
    }

    public void DeleteComment(int id)
    {
        var comment = _context.Comments.Find(id);
        _context.Comments.Remove(comment);
        _context.SaveChanges();    
    }
}