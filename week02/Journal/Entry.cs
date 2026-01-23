using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public int GetWordCount()
    {
        return _response.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.ResetColor();

        Console.WriteLine($"📅 Date: {_date}");
        Console.WriteLine($"😊 Mood: {_mood}");
        Console.WriteLine($"❓ Prompt: {_prompt}");
        Console.WriteLine($"✍️  Response: {_response}");
        Console.WriteLine($"📊 Word Count: {GetWordCount()}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================\n");
        Console.ResetColor();
    }

    public string ToFileString()
    {
        return $"{_date}|~|{_mood}|~|{_prompt}|~|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("|~|");
        return new Entry(parts[0], parts[2], parts[3], parts[1]);
    }
}
