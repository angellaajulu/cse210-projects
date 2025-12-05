using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public static class MindfulnessLog
{
    private const string LogFile = "activity_log.txt";
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    static MindfulnessLog()
    {
        Load();
    }

    private static void Load()
    {
        if (!File.Exists(LogFile)) return;

        var lines = File.ReadAllLines(LogFile);
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[1], out int count))
            {
                _activityCounts[parts[0]] = count;
            }
        }
    }
    private static void SaveFile()
    {
        using (StreamWriter writer = new StreamWriter(LogFile))
        {
            foreach (var kv in _activityCounts)
            {
                writer.WriteLine($"{kv.Key}:{kv.Value}");
            }
        }
    }

    public static void Increment(string activityName)
    {
        if (!_activityCounts.ContainsKey(activityName))
            _activityCounts[activityName] = 0;

        _activityCounts[activityName] ++;
        SaveFile();      
    }

    public static int GetCount(string activityName)
    {
        if (_activityCounts.ContainsKey(activityName))
            return _activityCounts[activityName];
        return 0;
    }

    public static void DisplayCounts()
    {
        Console.WriteLine("Activity Counts So Far:");
        foreach (var kv in _activityCounts)
        {
            Console.WriteLine($"- {kv.Key}: {kv.Value} times");
        }
        Console.WriteLine();
    }
}