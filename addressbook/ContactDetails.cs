using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class ContactDetails
    {
        //Initialising the contact details
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zipcode;
        public long phonenumber;
        public string email;


        //Reading the contact details
        public void ReadInput()
        {
            Console.WriteLine("Enter first name : ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter last name : ");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter address : ");
            address = Console.ReadLine();
            Console.WriteLine("Enter city name : ");
            city = Console.ReadLine();
            Console.WriteLine("Enter state name : ");
            state = Console.ReadLine();
            Console.WriteLine("Enter zip code : ");
            zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone number : ");
            phonenumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter email id : ");
            email = Console.ReadLine();
        }
        //Display Contact Details.....
        public static void DisplayContact(ContactDetails cd)
        {
            Console.WriteLine("Name : " + cd.firstName + " " + cd.lastName);
            Console.WriteLine("Address : " + cd.address);
            Console.WriteLine("City : " + cd.city);
            Console.WriteLine("State : " + cd.state);
            Console.WriteLine("Zipcode : " + cd.zipcode);
            Console.WriteLine("PhoneNumber : " + cd.phonenumber);
            Console.WriteLine("Email : " + cd.email);
        }
        public override string ToString()
        {
            return $"Name : {firstName} {lastName} \nAddress : {address} \nCity : {city} \nState : {state} \nZip : {zipcode} \nPhone : {phonenumber} \nEmail : {email}";
        }
    }
}