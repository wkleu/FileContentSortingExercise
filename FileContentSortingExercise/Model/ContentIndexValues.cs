using System;

namespace FileContentSortingExercise.Model
{
    /**
     * Get index value of header values
     */
    public class ContentIndexValues
    {
        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string Address = "Address";
        private const string PhoneNumber = "PhoneNumber";

        public ContentIndexValues(string[] headerValues)
        {
            FirstNameIndex = Array.IndexOf(headerValues, FirstName);
            LastNameIndex = Array.IndexOf(headerValues, LastName);
            AddressIndex = Array.IndexOf(headerValues, Address);
            PhoneNumberIndex = Array.IndexOf(headerValues, PhoneNumber);
        }

        public int FirstNameIndex { get; private set; }
        public int LastNameIndex { get; private set; }
        public int AddressIndex { get; private set; }
        public int PhoneNumberIndex { get; private set; }
    }
}
