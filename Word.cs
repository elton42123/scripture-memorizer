using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Word
    {
        // Private fields
        private string _text;      // original text of the token (may include punctuation)
        private bool _isHidden;

        public Word(string text)
        {
            _text = text ?? "";
            _isHidden = false;
        }

        // Expose whether this word is hidden (read-only)
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Hides the word (idempotent)
        public void Hide()
        {
            _isHidden = true;
        }

        // Return number of alphabetic characters in the word (used for underscore count)
        private int CountLetters()
        {
            int count = 0;
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                    count++;
            }
            return count;
        }

        // Returns display text: either the original token or underscores for the letters
        public string GetDisplayText()
        {
            if (!_isHidden)
                return _text;

            // Replace letters with underscores but keep punctuation and spacing intact.
            var sb = new StringBuilder();
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                    sb.Append('_');
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
