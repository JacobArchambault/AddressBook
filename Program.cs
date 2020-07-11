﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Transactions;
using static System.Console;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddEntries();
        }

        static List<Entry> AddEntries()
        {
            List<Entry> entries = new List<Entry> { };
            do
            {
                Entry entry = AddNewEntry();
                entries.Add(entry);
            } while (Continue() == "1");
            return entries;
        }
        static string Continue()
        {
            WriteLine("Press enter 1 to add another entry. Enter any other key to exit");
            return ReadLine();
        }
        static Entry AddNewEntry()
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
    }
}
