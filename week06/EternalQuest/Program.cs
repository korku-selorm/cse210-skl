// Program.cs
using System;

// Exceeded requirements by adding a level system where the user's level is calculated as score / 1000 + 1, displayed in the player info.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}