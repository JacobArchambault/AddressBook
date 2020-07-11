using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            } while (Continue() == "1");
            return entries;
        }

        private static Entry CreateNewEntry()
        {
            // Create a new entry, getting name and address, and phone number from user prompts
            return new Entry { Name = GetFieldFromUser("name"), EmailAddress = GetEmailAddress(), PhoneNumber = GetPhoneNumber() };
        }
        // Prompts the user to to enter a field value and returns the user's input.
        private static string GetFieldFromUser(string desiredField)
        {
            WriteLine($"Enter the entry's {desiredField}: ");
            return ReadLine();
        }
        private static string GetEmailAddress()
        {
            // gets the user's email provided it is valid.
            string email;
            while (!EmailAddressIsValidFormat(out email))
            {
                WriteLine("Email format is invalid. Try again.");
            }
            return email;
        }


        private static bool EmailAddressIsValidFormat(out string email)
        {

            // Regex pattern for an email address.
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            WriteLine("Enter the entry email address: ");
            email = ReadLine();
            // ensures that the email format is valid.
            return regex.IsMatch(email);
        }

        private static string GetPhoneNumber()
        {
            // gets the user's phone number provided it is valid.
            string phoneNumber;
            while (!PhoneNumberIsValidFormat(out phoneNumber))
            {
                WriteLine("Phone number must be in the following numeric format: XXX-XXX-XXXX");
            }
            return phoneNumber;
        }
        private static bool PhoneNumberIsValidFormat(out string phoneNumber)
        {

            Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");
            WriteLine("Enter the entry phone number, including area code: ");
            phoneNumber = ReadLine();
            // ensures that the phone number matches the format XXX-XXX-XXXX and has exactly 12 characters.
            return regex.IsMatch(phoneNumber) && phoneNumber.Length == 12;
        }

        // prompts the user for whether s/he wishes to add another entry and returns the user's response.
        private static string Continue()
        {
            WriteLine("Press enter 1 to add another entry. Enter any other key to exit");
            return ReadLine();
        }

    }
}
