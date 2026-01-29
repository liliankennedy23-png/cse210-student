using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity (Focus Reset)";
        Description = "Reset your focus with deep breathing, then plan your next 3 tasks.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("\nBreathe in... ");
            Countdown(4);
            elapsed += 4;

            Console.Write("\nBreathe out... ");
            Countdown(4);
            elapsed += 4;
        }

        // Productivity Prompt
        Console.WriteLine("\nTake a moment to jot down your top 3 tasks for the next hour:");
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"> Task {i}: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
                Takeaways.Add(task);
        }

        Console.WriteLine("\nGreat! Now you’re ready to tackle your tasks with focus.");
        PauseWithSpinner(3);
    }
}
