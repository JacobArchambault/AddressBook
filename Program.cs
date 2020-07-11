using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using static AddressBook.EntryListCreator;
using static System.Console;
using static System.IO.File;
namespace AddressBook
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Welcome to the address book maker app! Let's start adding some entries.");
            // Create a list of entries from user prompts.
            List<Entry> entries = AddEntriesToList();
            // Add entries from the entries list to the file phone-book.txt.
            AddEntries(entries, "phone-book.txt");
            WriteLine("The data was stored properly. Here it is!");
            // Open phone-book.txt with Notepad.
            OpenTextFileWithNotepad("phone-book.txt");
        }
        private static void AddEntries(List<Entry> fromEntryList, string toFile)
        {
            // Create a file with the name passed in as a string parameter, and a StreamWriter object to write to it. 
            using StreamWriter writer = CreateText(toFile);
            // With the StreamWriter, for each entry in the entry list passed in...
            fromEntryList.ForEach(entry =>
            {
                // ...get the entry number
                int entryNumber = fromEntryList.IndexOf(entry);
                // ...trim the phone number of dashes.
                string trimmedPhoneNumber = Regex.Replace(entry.PhoneNumber, "-", "");
                // ...and write that entry's number, name, address, and phone number trimmed of dashes to the file on a single line.
                writer.WriteLine($"Entry {entryNumber + 1}:\tName: {entry.Name},\temail address: {entry.EmailAddress},\tphone number: *{trimmedPhoneNumber}*");
            });
        }

        private static void OpenTextFileWithNotepad(string fileName)
        {
            Process.Start("notepad.exe", fileName);
        }
    }
}
