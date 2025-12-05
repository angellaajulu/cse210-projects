using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you did something really difficult.",
        "Think of a moment you helped someone in need.",
        "Think of a time you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this meaningful to you?",
        "What did you learn from this experience?",
        "How can you apply this to your life?"
    };

    public ReflectionActivity() 
        : base("Reflection", "This activity will help you reflect on meaningful moments in life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random rnd = new Random();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        Console.WriteLine();
        ShowSpinner(3);

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.WriteLine(_questions[rnd.Next(_questions.Count)]);
            ShowSpinner(4);
            elapsed += 4;
        }
        DisplayEndingMessage();
    }    
}