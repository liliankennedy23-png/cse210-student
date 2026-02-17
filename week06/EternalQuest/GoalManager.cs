using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _streak;
    private DateTime _lastCompletionDate;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _streak = 0;
        _lastCompletionDate = DateTime.MinValue;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Productivity Dashboard");
            Console.WriteLine("5. Save/Load");
            Console.WriteLine("6. Quit");

            Console.Write("Select option: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") ShowDashboard();
            else if (choice == "5") SaveLoad();
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("Priority (1-3): ");
        int priority = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, desc, points, priority));

        else if (type == "2")
            _goals.Add(new EternalGoal(name, desc, points, priority));

        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, priority, target, bonus));
        }
    }

    private void ListGoals()
    {
        _goals.Sort((a, b) => b.GetPriority().CompareTo(a.GetPriority()));

        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].Display();
        }
    }

    private void RecordEvent()
    {
        ListGoals();

        Console.Write("Select goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();

        UpdateStreak();

        int multiplier = _streak >= 5 ? 2 : 1;
        earned *= multiplier;

        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    private void UpdateStreak()
    {
        DateTime today = DateTime.Today;

        if (_lastCompletionDate == today.AddDays(-1))
            _streak++;
        else if (_lastCompletionDate != today)
            _streak = 1;

        _lastCompletionDate = today;
    }

    private void ShowDashboard()
    {
        Console.WriteLine("\n=== Productivity Dashboard ===");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {_score / 1000 + 1}");
        Console.WriteLine($"Streak: {_streak} days");
        Console.WriteLine($"Active Goals: {_goals.Count}");
        Console.WriteLine("==============================");
    }

    private void SaveLoad()
    {
        Console.WriteLine("1. Save");
        Console.WriteLine("2. Load");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                writer.WriteLine(_streak);
                writer.WriteLine(_lastCompletionDate);

                foreach (Goal g in _goals)
                    writer.WriteLine(g.GetSaveString());
            }
        }
        else
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");

            _score = int.Parse(lines[0]);
            _streak = int.Parse(lines[1]);
            _lastCompletionDate = DateTime.Parse(lines[2]);

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");

                if (parts[0] == "Simple")
                    _goals.Add(new SimpleGoal(parts));

                else if (parts[0] == "Eternal")
                    _goals.Add(new EternalGoal(parts));

                else if (parts[0] == "Checklist")
                    _goals.Add(new ChecklistGoal(parts));
            }
        }
    }
}
