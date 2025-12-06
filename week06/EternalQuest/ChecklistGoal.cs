using System;

namespace EternalQuest
{
    // A goal that needs to be done multiple times and awards a bonus on reaching the target.
    public class ChecklistGoal : Goal
    {
        // Members unique to checklist goals.
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
            : base(shortName, description, points)
        {
            _target = Math.Max(1, target);
            _bonus = Math.Max(0, bonus);
            _amountCompleted = 0;
        }

        // Loading constructor
        public ChecklistGoal(string shortName, string description, int points, int amountCompleted, int target, int bonus)
            : base(shortName, description, points)
        {
            _target = Math.Max(1, target);
            _bonus = Math.Max(0, bonus);
            _amountCompleted = Math.Max(0, amountCompleted);
        }

        public override int RecordEvent()
        {
            _amountCompleted++;
            int awarded = _points;
            // Award bonus only the moment the target is reached.
            if (_amountCompleted == _target)
            {
                awarded += _bonus;
            }
            return awarded;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetDetailsString()
        {
            return $"[{_amountCompleted}/{_target}] {_shortName} ({_description})";
        }

        // Format: Checklist|shortName|description|points|amountCompleted|target|bonus
        public override string GetStringRepresentation()
        {
            return $"Checklist|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
        }
    }
}