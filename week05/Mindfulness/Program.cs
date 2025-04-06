using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1": new BreathingActivity().Start(); break;
                case "2": new ReflectionActivity().Start(); break;
                case "3": new ListingActivity().Start(); break;
                case "4": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }
}
    


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1": new BreathingActivity().Start(); break;
                case "2": new ReflectionActivity().Start(); break;
                case "3": new ListingActivity().Start(); break;
                case "4": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }
}

    }
}