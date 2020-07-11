using System.Text.RegularExpressions;
using static System.Console;
namespace AddressBook
{
    static class EntryCreator
    {
        internal static Entry CreateNewEntry()
        {
            // Create a new entry, getting name, email address, and phone number from user prompts
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

    }
}
