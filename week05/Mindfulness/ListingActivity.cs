// Listing Activity
class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> prompts = new() { "Who are people you appreciate?", "What are your personal strengths?" };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity helps you reflect on positive aspects of life.";
    }

    protected override void RunActivity()
    {
        Random rnd = new();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        ShowSpinner(3);
        
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}

