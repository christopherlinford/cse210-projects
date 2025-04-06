
using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    private int _duration;
    private string _name;
    private string _description;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("How long in seconds, would you like your session? ");

        if (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Using default duration of 30 seconds.");
            _duration = 30;
        }

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        EndActivity();
    }

    private void EndActivity()
    {
        Console.WriteLine($"Great job! You completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    private void ShowSpinner(int seconds)
    {
        var spinner = new[] { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    public int GetDuration() => _duration;
    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;

    protected abstract void RunActivity();
}
