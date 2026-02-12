using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped recently?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life and plan productive tasks.";
    }

    protected override void PerformActivity()
    {
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.Write("You may begin in: ");
        Countdown(3);

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
                AddTakeaway(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");

        Console.WriteLine("\nNow list your top 3 tasks for today:");

        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Task {i}: ");
            string task = Console.ReadLine();
            AddTakeaway(task);
        }
    }
}
