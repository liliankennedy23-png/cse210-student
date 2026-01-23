using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of my day?",
        "Who made a positive impact on me today?",
        "What challenged me today?",
        "What am I grateful for today?",
        "What lesson did today teach me?",
        "If today had a title, what would it be?",
        "How did I grow today?"
    };

    private Random _random = new Random();
    private int _lastIndex = -1;

    public string GetRandomPrompt()
    {
        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (index == _lastIndex);

        _lastIndex = index;
        return _prompts[index];
    }
}
