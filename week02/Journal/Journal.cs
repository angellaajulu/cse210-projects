using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.WriteLine("\nYour Journal Entries:\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("-----------------------------------");
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date, Prompt, Entry, Mood");
            foreach (Entry entry in _entries)
            {
                string line = $"\"{entry._date}\",\"{entry._promptText.Replace("\"", "\"\"")}\",\"{entry._entryText.Replace("\"", "\"\"")}\",\"{entry._mood}\"";
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine($"Journal successfully saved to {file}");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            _entries.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("\",\"");
                if (parts.Length >= 4)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0].Trim('"'),
                        _promptText = parts[1].Trim('"'),
                        _entryText = parts[2].Trim('"'),
                        _mood = parts[3].Trim('"')
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal successfully loaded from {file}");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        } 
    }
}