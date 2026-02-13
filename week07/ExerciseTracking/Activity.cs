public abstract class Activity
{
    private string _date;
    protected int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract double GetCalories();

    public string GetIntensity()
    {
        double speed = GetSpeed();

        if (speed < 4)
            return "Low";
        else if (speed < 7)
            return "Medium";
        else
            return "High";
    }

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile, " +
               $"Calories: {GetCalories():0.0}, " +
               $"Intensity: {GetIntensity()}";
    }
}
