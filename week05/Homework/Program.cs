using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("George Burns", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // erived class 
        MathAssignment a2 = new MathAssignment("Rob Rodeo", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Missy Soda", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
    
