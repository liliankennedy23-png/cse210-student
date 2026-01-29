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
        Name = "Listing Activity (Gratitude + Task Planning)";
        Description = "Reflect on positives, then list top tasks to boost productivity.";
    }

    protected override void PerformActivity()
    {
        Random rand = new();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.Write("You may begin in: ");
        Countdown(3);

        List<string> items = new();
        DateTime end = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        Takeaways.AddRange(items);

        // Productivity Planning
        Console.WriteLine("\nNow, list your top 3 tasks for today:");
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"> Task {i}: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
                Takeaways.Add(task);
        }

        Console.WriteLine("\nExcellent! You now have a gratitude list and a productive plan.");
        PauseWithSpinner(3);
    }
}
