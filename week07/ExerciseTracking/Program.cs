using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("04 Nov 2022", 45, 12.0),
            new Swimming("05 Nov 2022", 40, 40)
        };

        double fastestSpeed = 0;
        double bestPace = double.MaxValue;
        Activity fastestActivity = null;
        Activity bestPaceActivity = null;

        Console.WriteLine("=== Fitness Activity Summary ===\n");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());

            if (activity.GetSpeed() > fastestSpeed)
            {
                fastestSpeed = activity.GetSpeed();
                fastestActivity = activity;
            }

            if (activity.GetPace() < bestPace)
            {
                bestPace = activity.GetPace();
                bestPaceActivity = activity;
            }
        }

        Console.WriteLine("\n--- Performance Highlights ---");
        Console.WriteLine($"Fastest Activity: {fastestActivity.GetType().Name} at {fastestSpeed:0.0} mph");
        Console.WriteLine($"Best Pace: {bestPaceActivity.GetType().Name} at {bestPace:0.0} min per mile");
    }
}
