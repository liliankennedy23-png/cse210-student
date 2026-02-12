using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    private int _duration;
    private List<string> _takeaways = new();

    private string _name;
    private string _description;

    public string Name
    {
        get { return _name; }
        protected set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        protected set { _description = value; }
    }

    protected int Duration => _duration;

    public void Run()
    {
        StartMessage();
        PerformActivity();
        EndMessage();
    }

    protected abstract void PerformActivity();

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"{Name}\n");
        Console.WriteLine(Description);

        Console.Write("\nEnter duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        Console.WriteLine("\nPrepare to begin...");
        PauseWithSpinner(3);
    }

    private void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithSpinner(2);

        Console.WriteLine($"You have completed the {Name} for {_duration} seconds.");

        if (_takeaways.Count > 0)
        {
            Console.WriteLine("\nSession Takeaways:");
            foreach (string item in _takeaways)
            {
                Console.WriteLine($"- {item}");
            }
        }

        PauseWithSpinner(3);
    }

    protected void AddTakeaway(string item)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            _takeaways.Add(item.Trim());
        }
    }

    protected void PauseWithSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b");
            index = (index + 1) % spinner.Length;
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
