using System;

namespace EternalQuest
{
    // Base class for all goals.
    
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        protected Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        public string ShortName => _shortName;
        public string Description => _description;
        public int Points => _points;

        // Record an occurrence of this goal. Returns number of points awarded.
        public abstract int RecordEvent();

        // Whether this goal is considered complete (Eternal goals return false).
        public abstract bool IsComplete();

        // String for display in lists (checkbox/indicator + name + description).
        public abstract string GetDetailsString();

        // String representation used for saving to file. Each subclass defines its own format.
        public abstract string GetStringRepresentation();
    }
}