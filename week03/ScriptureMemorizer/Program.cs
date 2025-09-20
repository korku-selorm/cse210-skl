using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        //created a library of scriptures for the user to choose from
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life"),

            new Scripture(new Reference("Proverb", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding" + "in all your ways submit to him, and he will make your paths straight."),

            new Scripture(new Reference("Psalm", 1, 1, 2), "Blessed is the man that walketh not in the counsel of the ungodly, " +
            "nor standeth in the way of sinners, nor sitteth in the seat of the scornful. " +
            "But his delight is in the law of the Lord; and in his law doth he meditate day and night.")
        };

        Scripture scripture;

        // display the available scriptures in the libray

        for (int i = 0; i < library.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {library[i].GetReference()}");
        }
        // asking the user for the scripture he or she wi like to memeorize from the list

        Console.WriteLine("Choose from the number next to the scripture you want to memorize ");
        string inputChoice = Console.ReadLine();

        //try to chnage the typeto int

        if (int.TryParse(inputChoice, out int choice) && choice >= 1 && choice <= library.Count)
        {
            scripture = library[choice - 1];
        }

        else
        {
            int randomIndex = random.Next(library.Count);
            scripture = library[randomIndex];
        }

        //choose dificulty

        Console.WriteLine("\n1. Easy(2 words X) \n2. Hard(3 words X) \n3. Expert(4 words X)");
        string difficulty = Console.ReadLine();
        int h = Convert.ToInt32(difficulty);
        int hard;
        switch (h)
        {
            case 1:
                hard = 2;
                break;

            case 2:
                hard = 3;
                break;

            case 3:
                hard = 4;
                break;

            default:
                hard = 1;
                break;
        }




        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllHidden())
            {
                Console.WriteLine("All the words are hidden good job champ!👍🏽");
                break;
            }


            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("\nSorry to see you go :(");
                break;
            }

            scripture.HideRandomWords(hard);

        }
    }
}
/*
    i Adda a functionality to have library of scripture so the use can choose from 
    i also added a functionality to select the difficulty and this determines the number of words to be hiden 
    and also i added a functionality to hide words that havement been already hidden 
    i added a functionality to also display the available scriptures in the library
 */