using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by guiding your breathing in and out slowly. Afterwards, you will set 3 focused tasks.";
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

        Console.WriteLine("\nNow, write your top 3 tasks to focus on next:");

        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Task {i}: ");
            string task = Console.ReadLine();
            AddTakeaway(task);
        }
    }
}
