
using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("0. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": DisplayPlayerInfo(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string input = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (input)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet.");
            return;
        }

        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter number: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= _goals.Count)
        {
            Goal selectedGoal = _goals[num - 1];
            selectedGoal.RecordEvent();
            int earnedPoints = selectedGoal.GetPoints();
            _score += earnedPoints;

            Console.WriteLine($"You earned {earnedPoints} points!");

            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                _score += bonus;
                Console.WriteLine($"Bonus achieved! +{bonus} points!");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    SimpleGoal sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) sg.RecordEvent(); // marks complete
                    _goals.Add(sg);
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(
                        parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[5]), int.Parse(parts[6]));
                    int completed = int.Parse(parts[4]);
                    for (int j = 0; j < completed; j++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;

                default:
                    Console.WriteLine("Unknown goal type in file.");
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
    }
}
