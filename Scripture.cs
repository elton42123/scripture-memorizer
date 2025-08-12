using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        // Private fields
        private Reference _reference;
        private List<Word> _words;

        // Constructor accepts a Reference and a raw scripture text
        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            _words = new List<Word>();

            // Split on spaces but keep punctuation attached to tokens.
            // This way tokens like "world," remain a single Word.
            var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
            {
                _words.Add(new Word(t));
            }
        }

        // Returns display text containing the reference and the scripture words
        public string GetDisplayText()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_reference.GetDisplayText());
            sb.AppendLine();

            for (int i = 0; i < _words.Count; i++)
            {
                sb.Append(_words[i].GetDisplayText());
                if (i < _words.Count - 1)
                    sb.Append(" ");
            }

            return sb.ToString();
        }

        // Hides up to 'count' random words that are not yet hidden.
        // Uses the provided Random instance for testability and fairness.
        public void HideRandomWords(int count, Random rng)
        {
            if (count <= 0) return;

            var visibleIndexes = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                    visibleIndexes.Add(i);
            }

            // If no visible words, nothing to do
            if (visibleIndexes.Count == 0) return;

            // Hide up to 'count' distinct visible words
            int hideCount = Math.Min(count, visibleIndexes.Count);
            for (int k = 0; k < hideCount; k++)
            {
                int pick = rng.Next(visibleIndexes.Count);
                int wordIndex = visibleIndexes[pick];

                _words[wordIndex].Hide();

                // remove that index from the pool so we don't pick it again
                visibleIndexes.RemoveAt(pick);
            }
        }

        // Returns true when all words are hidden
        public bool IsCompletelyHidden()
        {
            foreach (var w in _words)
            {
                if (!w.IsHidden())
                    return false;
            }
            return true;
        }
    }
}
