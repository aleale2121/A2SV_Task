using Task8_Blog.Models;

public class PostManager
{
    private readonly BlogContext _context;

    public PostManager()
    {
    }
    public PostManager(BlogContext context)
    {
        _context = context;
    }

    public Post CreatePost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public Post GetPostById(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Postid == id);
        if (post == null){
            return null;
        }
        var comments = _context.Comments.Where(c => c.Postid == id).ToList();
        post.Comments = comments;
        return post;
    }

    public List<PostSummary> GetAllPosts()
    {
        var posts = _context.Posts.Select(post => new PostSummary{
            Postid = post.Postid,
            Title = post.Title,
            Summary = post.Content.Substring(0, Math.Min(100, post.Content.Length))
         }).ToList();

        return  posts;
    }

    public void UpdatePost(Post post)
    {
        _context.Posts.Update(post);
        _context.SaveChanges();
    }

    public void DeletePost(int id)
    {
        var post = _context.Posts.Find(id);
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    public void AddMultiplePosts(List<Post> posts){
        _context.Posts.AddRange(posts);
        _context.SaveChanges();
    }
    
    public void DeleteMultiplePosts(List<Post> posts){
        _context.Posts.RemoveRange(posts); 
        _context.SaveChanges();
    }
}