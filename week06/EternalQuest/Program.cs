using System;

/*
EXCEEDING REQUIREMENTS:

This program exceeds core requirements by adding:

1. Daily streak tracking to encourage consistency.
2. A productivity dashboard with meaningful statistics.
3. Goal priority levels (High, Medium, Low).
4. A streak-based bonus multiplier system.

These additions transform the application from a simple
goal tracker into a productivity-driven habit-building system.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
