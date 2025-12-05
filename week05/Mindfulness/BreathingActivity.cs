using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you to breathe slowly.")
    {
        
    } 

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        int cycle = 0;

        while (cycle < duration)
        {
            Console.Write("Breathe in...");
            ShowCount(2);

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCount(2);
            Console.WriteLine();
            cycle += 6;
        }

        DisplayEndingMessage();
    }

    private void ShowCount(int count )
    {
        for (int i = count; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }  
}