using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       List<Activity> activities = new List<Activity>
        {
            new Running("13 Apr 2025", 30, 4.8),
            new Cycling("14 Apr 2025", 45, 20.0),
            new Swimming("15 Apr 2025", 30, 40)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        } 
    }
}

       