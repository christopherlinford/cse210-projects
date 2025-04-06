
using System;
using System.Collections.Generic;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        SetName("Breathing");
        SetDescription("This activity will help you relax by walking you through breathing in and out slowly.");
    }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        for (int i = 0; i < duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(3000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(3000);
        }
    }
}