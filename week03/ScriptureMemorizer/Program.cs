using System;
/*
 * CREATIVITY:
 * - Added a ScriptureLibrary class so the program selects a random scripture each run.
 * - Added difficulty levels (easy/normal/hard) to control how many words hide at a time.
 * - Improved word hiding logic so only visible words are chosen.
 */
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Program.");
        Console.WriteLine("Choose difficulty");
        Console.WriteLine("1. Easy (1 word at a time)");
        Console.WriteLine("2. Normal (3 words at a time)");
        Console.WriteLine("3. Hard (5 words at a time)");
        Console.Write("Enter choice (1-3): ");

        int hideCount = 3;
        string choice = Console.ReadLine();

        if (choice == "1") hideCount = 1;
        else if (choice == "3") hideCount = 5;

        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(hideCount);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are now hidden.");
                break;
            }
        }

    }
}