using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();
    private List<string> _usedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear(); // Reset if all used
        }

        string question;
        do
        {
            question = _questions[_random.Next(_questions.Count)];
        } while (_usedQuestions.Contains(question));

        _usedQuestions.Add(question);
        return question;
    }
}