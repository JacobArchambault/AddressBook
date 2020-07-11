using System.Collections.Generic;
using static AddressBook.EntryCreator;
using static System.Console;
namespace AddressBook
{
    internal static class EntryListCreator
    {
        // Adds Entries to list from user prompts.s
        internal static List<Entry> AddEntriesToList()
        {
            // Creates a list, 
            List<Entry> entries = new List<Entry> { };
            // Create a new entry and add it to our entry list. The do-while loop ensures at least one entry in the list. 
            do
            {
                Entry entry = CreateNewEntry();
                entries.Add(entry);
                // Add another entry if the user presses 1 when prompted to continue.
            } while (Continue());
            return entries;
        }

        // prompts the user for whether s/he wishes to add another entry and returns the user's response.
        private static bool Continue()
        {
            WriteLine("Press enter 1 to add another entry. Enter any other key to exit");
            return ReadLine() == "1";
        }
    }
}
