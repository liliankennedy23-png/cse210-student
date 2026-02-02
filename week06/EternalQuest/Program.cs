using System;
using System.Collections.Generic;
using System.IO;

/*
EXCEEDING REQUIREMENTS:
- Added a leveling system to increase productivity and motivation.
- Users level up every 1000 points and receive a title.
- This gamification encourages consistency and long-term goal completion.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine("\nEternal Quest Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save / Load");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": ShowScore(); break;
                case "5": SaveLoad(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select goal type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2")
            _goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
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
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");
        ShowLevel();
    }

    private void ShowScore()
    {
        Console.WriteLine($"\nTotal Score: {_score}");
        ShowLevel();
    }

    private void ShowLevel()
    {
        int level = _score / 1000 + 1;
        Console.WriteLine($"Level: {level} - Title: {GetTitle(level)}");
    }

    private string GetTitle(int level)
    {
        if (level < 3) return "Beginner Seeker";
        if (level < 5) return "Faithful Traveler";
        if (level < 8) return "Eternal Champion";
        return "Legend of Zion";
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
                foreach (Goal g in _goals)
                    writer.WriteLine(g.GetSaveString());
            }
        }
        else
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
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

// ================= BASE CLASS =================
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract void Display();
    public abstract string GetSaveString();
}

// ================= DERIVED CLASSES =================
public class SimpleGoal : Goal
{
    private bool _completed = false;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public SimpleGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3]))
    {
        _completed = bool.Parse(parts[4]);
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(_completed ? "X" : " ")}] {_name} ({_description})");
    }

    public override string GetSaveString()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_completed}";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public EternalGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3])) { }

    public override int RecordEvent() => _points;

    public override void Display()
    {
        Console.WriteLine($"[∞] {_name} ({_description})");
    }

    public override string GetSaveString()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}

public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3]))
    {
        _completed = int.Parse(parts[4]);
        _target = int.Parse(parts[5]);
        _bonus = int.Parse(parts[6]);
    }

    public override int RecordEvent()
    {
        _completed++;
        if (_completed == _target)
            return _points + _bonus;
        return _points;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(_completed >= _target ? "X" : " ")}] {_name} -- {_completed}/{_target}");
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_completed}|{_target}|{_bonus}";
    }
}
