using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        // Private fields (encapsulation)
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse; // nullable for single-verse references

        // Constructor for single verse (e.g., John 3:16)
        public Reference(string book, int chapter, int verse)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        // Constructor for verse range (e.g., Proverbs 3:5-6)
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            if (endVerse < startVerse)
                throw new ArgumentException("endVerse must be >= startVerse");

            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }
    }
}
