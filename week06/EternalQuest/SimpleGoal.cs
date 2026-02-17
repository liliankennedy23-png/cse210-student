using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, int priority)
        : base(name, description, points, priority)
    {
        _isComplete = false;
    }

    public SimpleGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]))
    {
        _isComplete = bool.Parse(parts[5]);
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }

        return 0;
    }

    public override void Display()
    {
        string status = _isComplete ? "X" : " ";
        Console.WriteLine($"[{status}] {_name} ({_description}) | Priority: {_priority}");
    }

    public override string GetSaveString()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_priority}|{_isComplete}";
    }
}
