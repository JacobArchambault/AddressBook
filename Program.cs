using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Transactions;
using static System.Console;
using System.IO;
using System.Diagnostics;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entry> entries = AddEntriesToList();
            AddEntries(entries, "phone-book.txt");
            OpenTextWithNotepad("phone-book.txt");
        }
        static List<Entry> AddEntriesToList()
        {
            List<Entry> entries = new List<Entry> { };
            do
            {
                Entry entry = CreateNewEntry();
                entries.Add(entry);
            } while (Continue() == "1");
            return entries;
        }
        static Entry CreateNewEntry()
        {
            return new Entry { Name = GetFieldFromUser("name"), Address = GetFieldFromUser("address"), PhoneNumber = GetPhoneNumber() };
        }
        static string GetFieldFromUser(string desiredField)
        {
            WriteLine($"Enter your {desiredField}: ");
            return ReadLine();
        }
        static string GetPhoneNumber()
        {
            string phoneNumber;
            while (!PhoneNumberIsValidFormat(out phoneNumber))
            {
                WriteLine("Phone number must be in the following numeric format: XXX-XXX-XXXX");
            }
            return phoneNumber;
        }
        static bool PhoneNumberIsValidFormat(out string phoneNumber)
        {
            Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");
            WriteLine("Enter your phone number, including area code: ");
            phoneNumber = ReadLine();
            return regex.IsMatch(phoneNumber) && phoneNumber.Length == 12;
        }
        static string Continue()
        {
            WriteLine("Press enter 1 to add another entry. Enter any other key to exit");
            return ReadLine();
        }


        static void OpenTextWithNotepad(string fileName)
        {
            Process.Start("notepad.exe", fileName);
        }

        static void AddEntries(List<Entry> fromEntryList, string toFile)
        {
            using StreamWriter writer = File.CreateText(toFile);
            fromEntryList.ForEach(entry =>
            {
                int entryNumber = fromEntryList.IndexOf(entry);
                writer.WriteLine($"Entry {entryNumber + 1}:\tName: {entry.Name},\tAddress: {entry.Address},\tphone number: {entry.PhoneNumber}");
            });
        }


    }
}
