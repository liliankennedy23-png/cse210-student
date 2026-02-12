using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // EXCEEDS CORE REQUIREMENTS:
        //
        // 1. Added productivity enhancements:
        //    - Breathing Activity includes top 3 task planning.
        //    - Reflection Activity converts reflections into actionable insights.
        //    - Listing Activity includes gratitude + task prioritization.
        //
        // 2. Session takeaway tracking that summarizes insights
        //    and tasks at the end of each activity.
        //
        // 3. Prevents duplicate reflection questions until all are used.
        //
        // 4. Improved spinner animation using backspace for smooth effect.

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness & Productivity Program ===\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }

        Console.WriteLine("\nThank you for using the program!");
    }
}
