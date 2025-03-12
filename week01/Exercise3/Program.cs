using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Random number between 1 and 100
        int guess = -1;

        Console.WriteLine("I have chosen a magic number between 1 and 100. Try to guess it!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            
            if (int.TryParse(Console.ReadLine(), out guess))
            {
                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!!!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}        

        //Console.WriteLine("What is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine());

        //while (guess != magicNumber)
        //{
            //Console.Write("What is your guess? ");
            //guess = int.Parse(Console.ReadLine());

            //if (magicNumber > guess)
            //{
                //Console.WriteLine("Higher");
            //}
            //else if (magicNumber < guess)
            //{
                //Console.WriteLine("Lower");
            //}
            //else
            //{
                //Console.WriteLine("You guessed it!");
            //}

