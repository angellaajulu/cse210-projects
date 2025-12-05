using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List things you're grateful for.",
        "List people who have influenced you positively.",
        "List personal strengths you have."
    };

    public ListingActivity() 
        : base("Listing", "This activity will help you reflect by listing positive things in your life.")
    {
    }

    public void Run()
    {
       DisplayStartingMessage();
       Random rnd = new Random();
       Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
       Console.WriteLine();
       Console.WriteLine("You may begin listing now: ");

       int duration = GetDuration();
       int count = 0;
       DateTime endTime = DateTime.Now.AddSeconds(duration);

       while (DateTime.Now < endTime)
        {
            Console.Write(">");
            Console.ReadLine();
            count ++;
        }

        Console.WriteLine($"You listed {count} items.");
        DisplayEndingMessage();
    }   
}