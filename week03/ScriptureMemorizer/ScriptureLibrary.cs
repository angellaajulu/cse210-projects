using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<(Reference reference, string text)> _scriptures;
    private Random _random = new Random();

    public ScriptureLibrary()
    {
        _scriptures = new List<(Reference, string)>
        {
            (
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son," +
                "that whosoever believeth in him should not perish, but have everlasting life. "
            ),
            (
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding." +
                " In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            (
                new Reference("Psalms",23, 1),
                "The Lord is my shepherd; I shall not want."
            ),
            (
                new Reference("Alma", 37, 6),
                "By small and simple things are great things brought to pass."
            )
        };
    }
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        var entry = _scriptures[index];

        return new Scripture(entry.reference, entry.text);
    }
} 