using System;

namespace EternalQuest
{
    // A goal that never completes; awards points every time it is recorded.
    public class EternalGoal : Goal
    {
        public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
        {
        }

        public override int RecordEvent()
        {
            return _points;
        }

        public override bool IsComplete() => false;

        public override string GetDetailsString()
        {
            return $"[∞] {_shortName} ({_description})";
        }

        // Format: Eternal|shortName|description|points
        public override string GetStringRepresentation()
        {
            return $"Eternal|{_shortName}|{_description}|{_points}";
        }
    }
}