using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage: ");
        string input = Console.ReadLine();

        //convert the input into an integer from a string

        int gradePercentage = int.Parse(input);

        //String VAriables to store the letter grade
        string letter = "";

        //determining the letter garde using if else statements
        if (gradePercentage >= 90)
        {
            letter = "A";
        }

        else if (gradePercentage >= 80)
        {
            letter = "B";
        }


        else if (gradePercentage >= 70)
        {
            letter = "C";
        }


        else if (gradePercentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        //Displaying the letter grade
        Console.WriteLine($"Your grade is: {letter}");

        //check if pass or fail

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You have passed th course");
        }

        else
        {
            Console.WriteLine("You did not pass. Better luck next time.");
        }
    }
}