
using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> _prompts = new()
    {
        "Think of a time you stood up for someone.",
        "Think of a time you did something difficult."
    };

    private static readonly List<string> _questions = new()
    {
        "Why was this meaningful?",
        "How did you feel when it was complete?"
    };

    public ReflectionActivity()
    {
        SetName("Reflection");
        SetDescription("This activity will help you reflect on moments of strength.");
    }

    protected override void RunActivity()
    {
        Random rnd = new();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        Thread.Sleep(3000);

        int duration = GetDuration();
        for (int i = 0; i < duration / 6; i++)
        {
            Console.WriteLine(_questions[rnd.Next(_questions.Count)]);
            Thread.Sleep(3000);
        }
    }
}