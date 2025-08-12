using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        // Stretch features explained (for grading):
        // 1) The program loads a small built-in library of scriptures and picks one at random.
        // 2) HideRandomWords hides only words that are not already hidden (so progress is monotonic).
        // 3) The user can press Enter repeatedly; typing "quit" (case-insensitive) ends the program.
        // These are documented here as required by the rubric.

        static void Main(string[] args)
        {
            var scriptures = new List<Scripture>()
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
                ),
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all your heart and lean not on your own understanding;"
                    + " in all your ways submit to him, and he will make your paths straight."
                ),
                new Scripture(
                    new Reference("Philippians", 4, 13),
                    "I can do all things through Christ who strengthens me."
                )
            };

            var rng = new Random();
            var selected = scriptures[rng.Next(scriptures.Count)];
            const int wordsToHidePerStep = 3; // configurable difficulty

            while (true)
            {
                Console.Clear();
                Console.WriteLine(selected.GetDisplayText());
                if (selected.IsCompletelyHidden())
                {
                    // final display shows everything hidden, then exit
                    Console.WriteLine("\nAll words are hidden. Well done!");
                    break;
                }

                Console.WriteLine("\nPress ENTER to hide more words, or type 'quit' to exit.");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                selected.HideRandomWords(wordsToHidePerStep, rng);
            }
        }
    }
}
