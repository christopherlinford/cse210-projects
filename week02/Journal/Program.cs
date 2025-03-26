using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menue:");
            Console.WriteLine("1. Write a new entry:");
            Console.WriteLine("2. Display journal:");
            Console.WriteLine("3. Save journal to file:");
            Console.WriteLine("4. Load journal from file:");
            Console.WriteLine("5. Exit:");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            
            {
                
            case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response));
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            }
            
        }
    }