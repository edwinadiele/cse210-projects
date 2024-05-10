using System;
using System.Collections.Generic;
using System.Linq;

// Class representing a single word in the scripture
class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public string GetText()
    {
        return _hidden ? new string('_', _text.Length) : _text;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }
}

// Class representing a reference, handling single verses and verse ranges
class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }

    public string GetReference()
    {
        return _reference;
    }
}

// Class representing a scripture, storing the reference and words
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private bool _welcomeDisplayed;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _welcomeDisplayed = false;
    }

    public void Display()
    {
        if (!_welcomeDisplayed)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Welcome to the Scripture Memorizer Program!!!!");
            Console.WriteLine($"Refer this program to friends and families.");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            _welcomeDisplayed = true;
        }
        
        Console.WriteLine($"Scripture Reference: {_reference.GetReference()}");
        foreach (var word in _words)
        {
            Console.Write($"{word.GetText()} ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        if (visibleWords.Count == 0)
        {
            return false; // All words are hidden
        }

        var random = new Random();
        var index = random.Next(visibleWords.Count);
        visibleWords[index].Hide();
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var scripture = new Scripture(new Reference("1 Nephi 3:7"), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            var success = scripture.HideRandomWord();
            if (!success)
            {
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}
