using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    // Manages goals, player score, level, badges, save/load and menu-related functionality.
    public class GoalManager
    {
        // Private member variables to satisfy encapsulation requirements.
        private List<Goal> _goals;
        private int _score;
        private int _level; // computed/stored level
        private List<string> _badges;
        private int _eternalEventCount; // track number of eternal events for badge triggers

        // Save filename default
        private const string DefaultSaveFile = "eternalquest_save.txt";

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _badges = new List<string>();
            _eternalEventCount = 0;
        }

        // Main menu loop entry point
        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("=== Eternal Quest ===");
                Console.WriteLine($"Score: {_score}    Level: {_level}");
                Console.WriteLine("1. Display Player Info");
                Console.WriteLine("2. List Goal Names");
                Console.WriteLine("3. List Goal Details");
                Console.WriteLine("4. Create New Goal");
                Console.WriteLine("5. Record Event (complete a goal)");
                Console.WriteLine("6. Save");
                Console.WriteLine("7. Load");
                Console.WriteLine("8. View Badges");
                Console.WriteLine("9. Quit");
                Console.Write("Choose an option (1-9): ");

                string input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        DisplayPlayerInfo();
                        break;
                    case "2":
                        ListGoalNames();
                        break;
                    case "3":
                        ListGoalDetails();
                        break;
                    case "4":
                        CreateGoal();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        Save(DefaultSaveFile);
                        break;
                    case "7":
                        Load(DefaultSaveFile);
                        break;
                    case "8":
                        DisplayBadges();
                        break;
                    case "9":
                        running = false;
                        Console.WriteLine("Goodbye — your progress will be saved.");
                        Save(DefaultSaveFile);
                        break;
                    default:
                        Console.WriteLine("Invalid option — enter a number between 1 and 9.");
                        break;
                }
            }
        }

        // Display top-line player info
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine($"Current Level: {_level}");
            Console.WriteLine($"Total Goals: {_goals.Count} (Completed: {_goals.Count(g => g.IsComplete())})");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        // Create a new goal interactively
        public void CreateGoal()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (complete N times)");
            Console.Write("Choice (1-3): ");
            string typeChoice = Console.ReadLine();

            Console.Write("Short name: ");
            string shortName = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            int points = PromptForInt("Points per event: ");

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(shortName, description, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    _goals.Add(new EternalGoal(shortName, description, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    int target = PromptForInt("How many times to complete (target): ");
                    int bonus = PromptForInt("Bonus points when target is reached: ");
                    _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type selected.");
                    break;
            }
        }

        // Helper to prompt for integer values
        private int PromptForInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        // Record an event for a chosen goal
        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available. Create a goal first.");
                return;
            }

            Console.WriteLine("Choose a goal to record (by number):");
            ListGoalNames();
            int choice = PromptForInt("Goal number: ") - 1;

            if (choice < 0 || choice >= _goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            Goal chosen = _goals[choice];
            int awarded = chosen.RecordEvent();

            // Track eternal event counts for a badge (do not change EternalGoal design)
            if (chosen is EternalGoal) _eternalEventCount++;

            _score += awarded;
            Console.WriteLine($"You earned {awarded} points!");

            bool leveledUp = UpdateLevel();
            if (leveledUp)
            {
                Console.WriteLine($"You leveled up to Level {_level}!");
                AwardBadge($"Level {_level} Achiever");
            }

            // Check badges based on events and state
            CheckAndAwardBadges(chosen);

            
            if (chosen.IsComplete())
            {
                Console.WriteLine("This goal is now complete!");
            }

            Console.WriteLine($"New total score: {_score}");
        }

        // Update stored level based on score. Returns true if level increased.
        private bool UpdateLevel()
        {
            int newLevel = (_score / 1000) + 1; // level increases every 1000 points
            if (newLevel > _level)
            {
                _level = newLevel;
                return true;
            }
            return false;
        }

        // Badge logic — award badges for milestone events
        private void CheckAndAwardBadges(Goal recentGoal)
        {
            // 1) First goal completed (simple or checklist) => Achiever I
            if (_goals.Any(g => g.IsComplete()) && !_badges.Contains("Achiever I"))
            {
                AwardBadge("Achiever I");
            }

            // 2) Five goals completed => Achiever II
            int completedCount = _goals.Count(g => g.IsComplete());
            if (completedCount >= 5 && !_badges.Contains("Achiever II"))
            {
                AwardBadge("Achiever II");
            }

            // 3) Ten goals completed => Achiever III
            if (completedCount >= 10 && !_badges.Contains("Achiever III"))
            {
                AwardBadge("Achiever III");
            }

            // 4) Checklist completed => Checklist Champion
            if (recentGoal is ChecklistGoal checklist && checklist.IsComplete() && !_badges.Contains("Checklist Champion"))
            {
                AwardBadge("Checklist Champion");
            }

            // 5) Eternal events recorded >= 25 => Eternal Grinder
            if (_eternalEventCount >= 25 && !_badges.Contains("Eternal Grinder"))
            {
                AwardBadge("Eternal Grinder");
            }

            // 6) Points milestone badges (e.g., 1000, 5000)
            var thresholds = new[] { 1000, 5000, 10000 };
            foreach (int t in thresholds)
            {
                string badgeName = $"Points {t}+";
                if (_score >= t && !_badges.Contains(badgeName))
                {
                    AwardBadge(badgeName);
                }
            }
        }

        // Adds a badge if not already present and prints a message
        private void AwardBadge(string badgeName)
        {
            if (_badges.Contains(badgeName)) return;
            _badges.Add(badgeName);
            Console.WriteLine($"🏅 Badge earned: {badgeName}!");
        }

    
        public void DisplayBadges()
        {
            Console.WriteLine("Badges:");
            if (_badges.Count == 0)
            {
                Console.WriteLine("- No badges earned yet.");
                return;
            }

            foreach (string b in _badges)
            {
                Console.WriteLine($"- {b}");
            }
        }

        // Save and Load implementation (simple, single-file format)
        // Format:
        // Line1: Score:level (e.g. 3450:4)
        // Line2: Badges: badge1,badge2,...  (empty after colon if none)
        // Then each following line is a goal string from GetStringRepresentation

        public void Save(string filename)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine($"{_score}:{_level}");
                writer.WriteLine($"Badges:{string.Join(",", _badges)}");
                writer.WriteLine($"EternalEventCount:{_eternalEventCount}");

                foreach (Goal g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }

                Console.WriteLine($"Saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save file: {ex.Message}");
            }
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found — nothing loaded.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length < 1) return;

                // Parse score and level
                string[] scoreParts = lines[0].Split(':');
                if (scoreParts.Length == 2 && int.TryParse(scoreParts[0], out int loadedScore) && int.TryParse(scoreParts[1], out int loadedLevel))
                {
                    _score = loadedScore;
                    _level = loadedLevel;
                }

                // Parse badges line
                if (lines.Length >= 2 && lines[1].StartsWith("Badges:"))
                {
                    string badgesPart = lines[1].Substring("Badges:".Length);
                    _badges = string.IsNullOrWhiteSpace(badgesPart) ? new List<string>() : badgesPart.Split(',').ToList();
                }
                else
                {
                    _badges = new List<string>();
                }

                // Parse eternal event count if present
                _eternalEventCount = 0;
                if (lines.Length >= 3 && lines[2].StartsWith("EternalEventCount:"))
                {
                    string epart = lines[2].Substring("EternalEventCount:".Length);
                    if (int.TryParse(epart, out int ecount)) _eternalEventCount = ecount;
                }

                // goals
                _goals = new List<Goal>();
                for (int i = 3; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    Goal g = ParseGoalLine(line);
                    if (g != null) _goals.Add(g);
                }

                Console.WriteLine($"Loaded {_goals.Count} goals from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load file: {ex.Message}");
            }
        }

        // Parse a goal representation line and create the appropriate Goal object
        private Goal ParseGoalLine(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 0) return null;

            string type = parts[0];
            try
            {
                switch (type)
                {
                    case "Simple":
                        // Simple|shortName|description|points|isComplete
                        if (parts.Length >= 5 && int.TryParse(parts[3], out int sp) && bool.TryParse(parts[4], out bool isComp))
                        {
                            return new SimpleGoal(parts[1], parts[2], sp, isComp);
                        }
                        break;
                    case "Eternal":
                        // Eternal|shortName|description|points
                        if (parts.Length >= 4 && int.TryParse(parts[3], out int ep))
                        {
                            return new EternalGoal(parts[1], parts[2], ep);
                        }
                        break;
                    case "Checklist":
                        // Checklist|shortName|description|points|amountCompleted|target|bonus
                        if (parts.Length >= 7 &&
                            int.TryParse(parts[3], out int cp) &&
                            int.TryParse(parts[4], out int amt) &&
                            int.TryParse(parts[5], out int tgt) &&
                            int.TryParse(parts[6], out int b))
                        {
                            return new ChecklistGoal(parts[1], parts[2], cp, amt, tgt, b);
                        }
                        break;
                    default:
                        // unknown type
                        break;
                }
            }
            catch
            {
                // If parsing failed, return null
            }
            return null;
        }
    }
}