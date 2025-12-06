using System;

namespace EternalQuest
{
    class Program
    {
        
        // ENHANCEMENT: LEVELING + BADGES
        // Users now earn Experience (XP) and level up as they record goals.
        // Badges are awarded at point milestones:
        //  • Bronze – 500 points
        //  • Silver – 1500 points
        //  • Gold – 3000 points
        // Badges unlock automatically and display a notification when earned.
        // This feature motivates users without affecting core functionality.

        static void Main(string[] args)
        {
            var manager = new GoalManager();
            manager.Load("eternalquest_save.txt");

            manager.Start();
        }
    }
}