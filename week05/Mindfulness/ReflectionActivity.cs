// Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> prompts = new() { "Think of a time you stood up for someone.", "Think of a time you did something difficult." };
    private static readonly List<string> questions = new() { "Why was this meaningful?", "How did you feel when it was complete?" };

    public ReflectionActivity()
    {
        name = "Reflection";
        description = "This activity will help you reflect on moments of strength.";
    }

    protected override void RunActivity()
    {
        Random rnd = new();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        ShowSpinner(3);
        
        for (int i = 0; i < duration / 6; i++)
        {
            Console.WriteLine(questions[rnd.Next(questions.Count)]);
            ShowSpinner(3);
        }
    }
}