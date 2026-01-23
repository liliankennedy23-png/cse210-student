using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("📭 The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void DisplayStats()
    {
        int totalWords = 0;

        foreach (Entry entry in _entries)
        {
            totalWords += entry.GetWordCount();
        }

        Console.WriteLine("📘 Journal Statistics");
        Console.WriteLine($"Entries: {_entries.Count}");
        Console.WriteLine($"Total Words Written: {totalWords}\n");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine("❌ File not found.\n");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            _entries.Add(Entry.FromFileString(line));
        }
    }
}
