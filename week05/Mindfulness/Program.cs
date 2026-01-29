using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> activityLog = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness & Productivity Program ===\n");
            Console.WriteLine("1. Breathing Activity (Focus Reset)");
            Console.WriteLine("2. Reflection Activity (Actionable Insights)");
            Console.WriteLine("3. Listing Activity (Gratitude + Task Planning)");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
                break;

            if (activity == null)
                continue;

            activity.Run();

            if (!activityLog.ContainsKey(activity.Name))
                activityLog[activity.Name] = 0;

            activityLog[activity.Name]++;
        }

        Console.WriteLine("\nThanks for using the Mindfulness & Productivity Program!");
    }
}
