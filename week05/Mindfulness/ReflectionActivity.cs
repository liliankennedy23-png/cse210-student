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
        "How can you apply this lesson today?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        PauseWithSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> unusedQuestions = new(_questions);

        while (DateTime.Now < endTime)
        {
            if (unusedQuestions.Count == 0)
            {
                unusedQuestions = new List<string>(_questions);
            }

            int index = random.Next(unusedQuestions.Count);
            string question = unusedQuestions[index];
            unusedQuestions.RemoveAt(index);

            Console.WriteLine($"\n{question}");
            Console.Write("Your reflection: ");
            string response = Console.ReadLine();

            AddTakeaway(response);

            PauseWithSpinner(2);
        }
    }
}
