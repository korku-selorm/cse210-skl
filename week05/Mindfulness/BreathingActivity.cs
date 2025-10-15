using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            if (DateTime.Now >= endTime) break;
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}