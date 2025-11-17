using System;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(" ")
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        if (visibleWords.Count == 0) return;
        
        int count = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < count; i++)
        {
          int index = _random.Next(visibleWords.Count);
          visibleWords[index].Hide();
          visibleWords.RemoveAt(index);  
        }
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {text}";
    }
}