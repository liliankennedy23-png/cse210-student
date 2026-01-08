using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine + or - sign
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // Handle special cases
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }

        // Display grade
        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // Determine pass or fail
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time.");
        }
    }
}
