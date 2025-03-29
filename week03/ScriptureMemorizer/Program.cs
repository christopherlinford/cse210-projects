//This is a good program for learning scripture or texts

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = ScriptureLoader.LoadScriptures("scriptures.txt");
        Scripture scripture;
        
        if (scriptures.Count > 0)
        {
            Random random = new Random();
            scripture = scriptures[random.Next(scriptures.Count)];
        }
        else
        {
            scripture = new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways acknowledge Him, and He shall direct your paths.");
            Console.WriteLine("No scripture file found or empty. Defaulting to Proverbs 3:5-6.\n");
        }
        
        Console.Clear();
        Console.WriteLine("Select difficulty level:");
        Console.WriteLine("1. Easy (1 word per turn)");
        Console.WriteLine("2. Medium (2 words per turn)");
        Console.WriteLine("3. Hard (3 words per turn)");
        
        int wordsToHide = 2;
        string difficulty = Console.ReadLine();

        switch (difficulty)
        {
            case "1":
                wordsToHide = 1;
                break;
            case "2":
                wordsToHide = 2;
                break;
            case "3":
                wordsToHide = 3;
                break;
            default:
                Console.WriteLine("Invalid choice, defaulting to Medium.");
                break;
        }

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words, type 'hint' for a clue, or type 'quit' to exit.");
            string input = Console.ReadLine()?.ToLower();

            if (input == "quit")
                break;
            if (input == "hint")
                scripture.RevealWord();
            else
                scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ending.");
    }
}
