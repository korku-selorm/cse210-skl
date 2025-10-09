public class Video
{
    private string _title;
    private string _channel;
    private int _length;
    private int _viewCount; // New field for tracking views
    private List<Comment> _comments;

    public Video(string title, string channel, int length)
    {
        _title = title;
        _channel = channel;
        _length = length;
        _viewCount = 0; // Initialize view count to 0
        _comments = new List<Comment>();
    }

    public void SetComment(string author, string text)
    {
        Comment comment = new Comment(author, text);
        _comments.Add(comment);
    }

    public void AddView() // New method to increment view count
    {
        _viewCount++;
    }

    public int GetCommentNumber()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {_title}");
        Console.WriteLine($"Channel: {_channel}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"View Count: {_viewCount}"); // Display view count
        Console.WriteLine($"Number of comments: {GetCommentNumber()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
    }
}