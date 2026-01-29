using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you use this experience in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity (Actionable Insights)";
        Description = "Reflect on moments of strength and turn insights into actions.";
    }

    protected override void PerformActivity()
    {
        Random rand = new();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        PauseWithSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(Duration);
        var unusedQuestions = new List<string>(_questions);

        while (DateTime.Now < end)
        {
            if (unusedQuestions.Count == 0)
                unusedQuestions = new List<string>(_questions);

            string question = unusedQuestions[rand.Next(unusedQuestions.Count)];
            unusedQuestions.Remove(question);

            Console.WriteLine($"\n{question}");
            Console.Write("Your reflection: ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                Takeaways.Add(answer + " (Apply today)");
            }

            PauseWithSpinner(2);
        }
    }
}
