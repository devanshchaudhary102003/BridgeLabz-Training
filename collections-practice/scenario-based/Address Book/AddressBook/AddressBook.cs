namespace AddressBook
{
    public class AddressBook
    {
        private string FirstName;
        private string LastName;
        private string Address;
        private string City;
        private string State;
        private string Zip;
        private string PhoneNumber;
        private string Email;

        public string firstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        public string lastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }

        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }

        public string city
        {
            get
            {
                return City;
            }
            set
            {
                City = value;
            }
        }

        public string state
        {
            get
            {
                return State;
            }
            set
            {
                State = value;
            }
        }

        public string zip
        {
            get
            {
                return Zip;
            }
            set
            {
                Zip = value;
            }
        }

        public string phoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                PhoneNumber = value;
            }
        }

        public string email
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

        public override string? ToString()
        {
            return "First Name: "+FirstName+" ,Last Name: "+LastName+" ,Address: "+Address+" ,City: "+City+" ,State: "+State+" ,Zip: "+Zip+" ,Phone Number: "+PhoneNumber+" ,Email Id : "+Email;
        }
    }
}