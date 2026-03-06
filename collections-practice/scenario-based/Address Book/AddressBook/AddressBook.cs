namespace AddressBook
{
    // Model class representing a contact person in address book
    public class AddressBook
    {
        // Private fields for contact details
        private string? FirstName;
        private string? LastName;
        private string? Address;
        private string? City;
        private string? States;
        private string? Zip;
        private string? PhoneNumber;
        private string? Email;

        // Property for First Name
        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        // Property for Last Name
        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        // Property for Address
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        // Property for City
        public string city
        {
            get { return City; }
            set { City = value; }
        }

        // Property for State
        public string state
        {
            get { return States; }
            set { States = value; }
        }

        // Property for Zip
        public string zip
        {
            get { return Zip; }
            set { Zip = value; }
        }

        // Property for Phone Number
        public string phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        // Property for Email
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        // UC10 - Override ToString method to print contact details
        public override string? ToString()
        {
            return "First Name: "+FirstName+" ,Last Name: "+LastName+" ,Address: "+Address+" ,City: "+City+" ,State: "+States+" ,Zip: "+Zip+" ,Phone Number: "+PhoneNumber+" ,Email Id : "+Email;
        }
    }
}