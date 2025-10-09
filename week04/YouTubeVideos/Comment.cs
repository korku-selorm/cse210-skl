public class Comment
{
    private string _author;
    private string _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Comment by {_author}: {_text}");
    }
}
