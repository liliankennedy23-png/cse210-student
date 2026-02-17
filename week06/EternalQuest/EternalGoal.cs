using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points, int priority)
        : base(name, description, points, priority)
    {
    }

    public EternalGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]))
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override void Display()
    {
        Console.WriteLine($"[∞] {_name} ({_description}) | Priority: {_priority}");
    }

    public override string GetSaveString()
    {
        return $"Eternal|{_name}|{_description}|{_points}|{_priority}";
    }
}
