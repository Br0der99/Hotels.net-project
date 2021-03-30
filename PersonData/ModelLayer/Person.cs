using System;

namespace PersonData.ModelLayer
{
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }



        public bool IsPersonEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Person() { }

        public Person(string firstName, string lastName, string phoneNo, string address, string zipCode, string city, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Email = email;

        }

        

    }
}
