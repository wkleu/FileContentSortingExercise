using System;

namespace FileContentSortingExercise.Model
{
    /**
     * Represents the content read
     */
    public class ContentItem
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnAddressChanged();
            }
        }

        private void OnAddressChanged()
        {
            var firstSpace = _address.IndexOf(" ", StringComparison.Ordinal);
            StreetName = _address.Substring(firstSpace + 1);
        }

        public string StreetName { get; private set; }

        public string PhoneNumber { get; set; }

    }
}
