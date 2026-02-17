using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected int _priority;

    public Goal(string name, string description, int points, int priority)
    {
        _name = name;
        _description = description;
        _points = points;
        _priority = priority;
    }

    public int GetPriority()
    {
        return _priority;
    }

    public abstract int RecordEvent();

    public abstract void Display();

    public abstract string GetSaveString();
}
