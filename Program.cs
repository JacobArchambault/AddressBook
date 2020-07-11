using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Text.RegularExpressions;
using static System.Console;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Entry entry = NewEntry();
            WriteLine($"{entry.Name}, {entry.Address}, {entry.PhoneNumber}");
        }
        public static Entry NewEntry()
        {
            Entry entry = new Entry { };

            WriteLine("Enter your name: ");
            entry.Name = ReadLine();

            WriteLine("Enter your address: ");
            entry.Address = ReadLine();
            string phoneNumber;
            while (!PhoneNumberIsValidFormat(out phoneNumber))
            {
                WriteLine("Phone number must be in the following numeric format: XXX-XXX-XXXX");
            }
            entry.PhoneNumber = phoneNumber;
            return entry;
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
