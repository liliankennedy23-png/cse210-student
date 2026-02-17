using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int priority, int target, int bonus)
        : base(name, description, points, priority)
    {
        _target = target;
        _bonus = bonus;
        _completed = 0;
    }

    public ChecklistGoal(string[] parts)
        : base(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]))
    {
        _completed = int.Parse(parts[5]);
        _target = int.Parse(parts[6]);
        _bonus = int.Parse(parts[7]);
    }

    public override int RecordEvent()
    {
        _completed++;

        if (_completed == _target)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override void Display()
    {
        string status = _completed >= _target ? "X" : " ";
        Console.WriteLine($"[{status}] {_name} -- {_completed}/{_target} | Priority: {_priority}");
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_priority}|{_completed}|{_target}|{_bonus}";
    }
}
