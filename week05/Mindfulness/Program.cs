using System;

// Enhancement: Added MindfulnessLog program with feature that tracks how many times each activity is completed
// and displays the updated count at the end of each session.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Program.");

        int choice = 0;
        
        while (choice != 4)
        {
            Console.Clear();
            MindfulnessLog.DisplayCounts();
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();

            if (choice == 1)
            {
                BreathingActivity  breathing = new BreathingActivity();
                breathing.Run();
                Console.Clear();
            }
            else if (choice == 2)
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
                Console.Clear();
            }
            else if (choice ==3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                Console.Clear();
            }
        }
    }
}