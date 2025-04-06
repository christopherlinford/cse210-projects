
using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> _prompts = new()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?"
    };

    public ListingActivity()
    {
        SetName("Listing");
        SetDescription("This activity helps you reflect on positive aspects of life.");
    }

    protected override void RunActivity()
    {
        Random rnd = new();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        Thread.Sleep(3000);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}