// Base class for mindfulness activities
abstract class MindfulnessActivity
{
    protected int duration;
    protected string name;
    protected string description;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {name} Activity");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        EndActivity();
    }

    protected abstract void RunActivity();

    protected void EndActivity()
    {
        Console.WriteLine($"Great job! You completed the {name} activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}