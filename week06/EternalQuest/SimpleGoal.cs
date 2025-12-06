using System;

namespace EternalQuest
{
    // A goal that can be completed once. Awards points one time.
    public class SimpleGoal : Goal
    {
        // Private field to track completion.
        private bool _isComplete;

        public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
        {
            _isComplete = false;
        }

        // Constructor used when loading from file to set completion state.
        public SimpleGoal(string shortName, string description, int points, bool isComplete) : base(shortName, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            // If already complete, no additional points.
            if (_isComplete) return 0;

            _isComplete = true;
            return _points;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetDetailsString()
        {
            string checkbox = _isComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description})";
        }

        // Format: Simple|shortName|description|points|isComplete
        public override string GetStringRepresentation()
        {
            return $"Simple|{_shortName}|{_description}|{_points}|{_isComplete}";
        }
    }
}