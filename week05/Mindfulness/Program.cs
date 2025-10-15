// To exceed requirements, I added a fourth activity: GratitudeActivity, which prompts the user to list things they are grateful for,
// with a twist of categorizing them randomly (e.g., people, experiences, possessions). This is similar to Listing but focused on gratitude.
// Additionally, I ensured that in ReflectingActivity, questions are not repeated until all have been used once in the session.

using System;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity"); // Exceeding: added fourth activity
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.Run();
        }
    }
}