using System;


public class Scripture
{
    private Reference _reference;

    private List<Word> _words;

    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

   public void HideRandomWords(int numberToHide)
    {
        // collect all indexes of visible words
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        if (visibleIndexes.Count == 0)
        {
            return; // nothing to hide
        }

        int count = Math.Min(numberToHide, visibleIndexes.Count);

        for (int i = 0; i < count; i++)
        {
            // pick a random index from visibleIndexes
            int randIndex = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[randIndex];

            // hide the word
            _words[wordIndex].Hide();

            // remove it from visibleIndexes so it is not picked again
            visibleIndexes.RemoveAt(randIndex);
        }
    }


    public string GetDisplayText()
    {
        string display = _reference.GetReference();

        foreach (Word w in _words)
        {
            display += " " + w.GetDisplayText();
        }

        return display;
    }


    public bool AllHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    //adding a behavior to siaplay the references
    public string GetReference()
    {
        return _reference.GetReference();
    }
}