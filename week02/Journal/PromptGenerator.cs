using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private List<string> _quotes;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        _quotes = new List<string>
        {
            "Keep going. You're doing better than you think.",
            "Gratitude turns what we have into enough.",
            "Small steps every day lead to big change.",
            "Even cloudy days can't hide your light.",
            "Progress, not perfection."
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetDailyQuote()
    {
        Random random = new Random();
        int index = random.Next(_quotes.Count);
        return _quotes[index];
    }
}