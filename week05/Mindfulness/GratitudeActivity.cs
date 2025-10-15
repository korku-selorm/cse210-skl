using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private List<string> _categories = new List<string>
    {
        "people in your life",
        "experiences you've had",
        "possessions you own",
        "skills you possess",
        "places you've visited"
    };

    private Random _random = new Random();

    public GratitudeActivity() : base("Gratitude Activity", "This activity will help you cultivate gratitude by listing things you're thankful for in a specific category.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string category = GetRandomCategory();
        Console.WriteLine($"List as many things as you can that you're grateful for in the category: {category}");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        List<string> items = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        Console.WriteLine($"You listed {items.Count} items you're grateful for!");
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomCategory()
    {
        return _categories[_random.Next(_categories.Count)];
    }
}