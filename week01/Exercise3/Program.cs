using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a Random object for generating the magic number
        Random randomGenerator = new Random();

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize guess variable
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine("I have selected a number between 1 and 100.");
            Console.WriteLine("Try to guess it!");

            // Loop until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.WriteLine("What is your guess?");
                string input = Console.ReadLine();

                // Convert input to integer
                guess = int.Parse(input);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thank you for playing! Goodbye.");
    }
}