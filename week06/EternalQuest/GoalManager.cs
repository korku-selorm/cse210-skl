// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        int level = _score / 1000 + 1;
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {level}");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the short name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typeChoice == "1")
        {
            newGoal = new SimpleGoal(name, desc, points);
        }
        else if (typeChoice == "2")
        {
            newGoal = new EternalGoal(name, desc, points);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, desc, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        _goals.Add(newGoal);
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score:{_score}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        _score = 0;

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line.StartsWith("Score:"))
            {
                _score = int.Parse(line.Split(":")[1]);
                continue;
            }

            string[] parts = line.Split(":");
            if (parts.Length < 2) continue;

            string type = parts[0];
            string[] data = parts[1].Split(",");

            Goal goal = null;

            if (type == "SimpleGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);
                goal = new SimpleGoal(name, desc, points, isComplete);
            }
            else if (type == "EternalGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                goal = new EternalGoal(name, desc, points);
            }
            else if (type == "ChecklistGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                int completed = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int bonus = int.Parse(data[5]);
                goal = new ChecklistGoal(name, desc, points, completed, target, bonus);
            }

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}