using System;
using System.Threading;

abstract class Activity
{
    private int _duration;
    protected List<string> Takeaways = new(); // For session summary

    public string Name { get; protected set; }
    public string Description { get; protected set; }

    public void Run()
    {
        StartMessage();
        PerformActivity();
        EndMessage();
    }

    protected abstract void PerformActivity();

    protected int Duration => _duration;

    protected void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"{Name}\n");
        Console.WriteLine(Description);
        Console.Write("\nEnter duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid number: ");
        }

        Console.WriteLine("\nPrepare to begin...");
        PauseWithSpinner(3);
    }

    protected void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithSpinner(2);
        Console.WriteLine($"You completed the {Name} for {_duration} seconds.");
        PauseWithSpinner(1);

        if (Takeaways.Count > 0)
        {
            Console.WriteLine("\nSession Takeaways:");
            foreach (var item in Takeaways)
                Console.WriteLine($"- {item}");
        }

        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        DateTime end = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
