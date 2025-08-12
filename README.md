# W03 Scripture Memorizer Program

## Overview
This is the **W03 Scripture Memorizer Program** for CSE 210.  
The program helps users memorize scriptures by progressively hiding words until the entire scripture is hidden.  
It demonstrates **encapsulation** and **object-oriented programming** principles using multiple classes.

---

## Features

### Core Requirements
- Stores a scripture, including both the reference and the text.
- Supports scriptures with single verses and verse ranges (e.g., `John 3:16` or `Proverbs 3:5-6`).
- Displays the scripture with its reference.
- Allows the user to:
  - Press **Enter** to hide random words.
  - Type `quit` to exit the program.
- Words are hidden by replacing letters with underscores (`_`), keeping punctuation intact.
- Program ends when:
  - All words are hidden, **or**
  - The user types `quit`.

---

### Stretch Features (Creativity)
- **Random scripture selection** from a small built-in library (instead of a single hardcoded verse).
- **Smart hiding**: only words that are not already hidden are selected to be hidden.
- **Adjustable difficulty**: number of words hidden per step can be changed in the code via `wordsToHidePerStep`.

---

## Class Structure
The program uses **four classes**:

1. **`Program`**
   - Controls program flow and user interaction.
2. **`Reference`**
   - Stores and formats the scripture reference.
   - Handles both single verse and verse ranges.
3. **`Scripture`**
   - Stores the reference and scripture text as `Word` objects.
   - Responsible for hiding words and displaying scripture.
4. **`Word`**
   - Stores the text of a single word and whether it’s hidden.
   - Handles the logic for displaying underscores.

---


## How to Run

### Using .NET CLI
1. Navigate to the project folder containing `ScriptureMemorizer.csproj`.
2. Run:
   ```bash
   dotnet run
