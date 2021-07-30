using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        public static Dictionary<string, ContactBook> ContactBooks = new Dictionary<string, ContactBook>();
        // Dictionary for Contacts which are in same City
        public static Dictionary<string, List<ContactDetails>> CityWiseContacts = new Dictionary<string, List<ContactDetails>>();
        // Dictionary for Contacts which are in same State
        public static Dictionary<string, List<ContactDetails>> StateWiseContacts = new Dictionary<string, List<ContactDetails>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            ContactBook book = new ContactBook();
            ContactDetails cd = new ContactDetails();
            string bookName;
            bool end = false;
            int option;
            while (!end)
            {
                Console.WriteLine("1.Add contack book\n2.Work with exisiting contact book\n3.View contact by city or state\n4.Count of contacts in city or state\n5.Read from file\n6.Exit");
                Console.WriteLine("Choose an option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //Creating an address book
                        Console.WriteLine("Enter name of the contact book :");
                        bookName = Console.ReadLine();
                        ContactBooks.Add(bookName, new ContactBook());
                        Operations(bookName);
                        break;
                    case 2:
                        //Editing in existing address book
                        Console.WriteLine("Enter name of the contact book yow want work with ");
                        bookName = Console.ReadLine();
                        Operations(bookName);
                        break;
                    case 3:
                        //View the contact by city name or state name
                        ViewContactByCityOrState();
                        break;
                    case 4:
                        CountPersonByCityOrState();
                        break;
                    case 5:
                        Console.WriteLine("Enter the name of the contact book you wish to read : ");
                        bookName = Console.ReadLine();
                        FileOperation.ReadFromFile(bookName);
                        break;
                    case 6:
                        end = true;
                        break;
                }
            }
        }
        //Performing operations in address book
        public static void Operations(string bookName)
        {
            ContactBook book = new ContactBook();
            ContactDetails cd = new ContactDetails();
            bool end = false;
            while (!end)
            {
                //Choosing option
                Console.WriteLine("Choose an option to perform in " + bookName + " : ");
                Console.WriteLine("1.Adding the contact details to Address Book");
                Console.WriteLine("2.Edit the contact details");
                Console.WriteLine("3.Delete the contact details");
                Console.WriteLine("4.Number of contacts in address book");
                Console.WriteLine("5.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //Adding contact details
                        Console.WriteLine("Enter a name :");
                        string names = Console.ReadLine();
                        int index = book.FindByName(names);
                        if (index == -1)
                        {
                            Console.WriteLine("The name with that contact does not exist so I am adding it....");
                            cd.ReadInput();
                            book.AddContact(cd);
                            AddCityOrState(cd);
                            FileOperation.WriteInToFile(bookName, book);
                            Console.WriteLine("Contact updated successfully in " + bookName);
                        }
                        else
                        {
                            Console.WriteLine("Contact with the name {0} already exists in {1}", names, bookName);
                        }
                        break;
                    case 2:
                        //Editing contact details
                        Console.WriteLine("Enter the name of a contact you wish to edit in " + bookName + " : ");
                        string name = Console.ReadLine();
                        int index2 = book.FindByName(name);
                        if (index2 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            Console.WriteLine("Contact exists. Now you can edit it..");
                            ContactDetails cd2 = new ContactDetails();
                            cd2.ReadInput();
                            book.contactList[index2] = cd2;
                            FileOperation.WriteInToFile(bookName, book);
                            Console.WriteLine("Contact Details updated successfully in " + bookName);
                        }
                        break;
                    case 3:
                        //Deleting contact details
                        Console.WriteLine("Enter the first name of a contact you wish to delete in " + bookName + " : ");
                        string firstname = Console.ReadLine();
                        int index3 = book.FindByName(firstname);
                        if (index3 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            book.DeleteContact(index3);
                            Console.WriteLine("Contact Details deleted successfully in " + bookName);
                        }
                        break;
                    case 4:
                        //Printing number of contacts
                        Console.WriteLine("Count of contacts in " + bookName + " : " + ContactBook.cnt);
                        break;
                    case 5:
                        //Exit
                        end = true;
                        break;
                    default:
                        break;
                }
            }
            //Printing number of contact books
            Console.WriteLine("Number of contact books : " + ContactBooks.Count);
        }
        //Adding the city name or state name in to the dictionary
        public static void AddCityOrState(ContactDetails cd)
        {
            if (!CityWiseContacts.ContainsKey(cd.city))
            {
                List<ContactDetails> cityContact = new List<ContactDetails>();
                cityContact.Add(cd);
                CityWiseContacts.Add(cd.city, cityContact);
            }
            else
            {
                List<ContactDetails> cityContact = CityWiseContacts[cd.city];
                cityContact.Add(cd);
            }
            if (!StateWiseContacts.ContainsKey(cd.state))
            {
                List<ContactDetails> stateContact = new List<ContactDetails>();
                stateContact.Add(cd);
                StateWiseContacts.Add(cd.state, stateContact);
            }
            else
            {
                List<ContactDetails> stateContact = StateWiseContacts[cd.state];
                stateContact.Add(cd);
            }
        }
        //Viewing the contact by city name or state name
        public static void ViewContactByCityOrState()
        {
            ContactDetails cd = new ContactDetails();
            int choice;
            Console.WriteLine(" 1.View Person Contact By City \n 2.View Person Contact By State");
            Console.Write("\n Select Options : ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    //Searching contact by city name
                    Console.WriteLine("Enter the city name : ");
                    string cityName = Console.ReadLine();
                    List<ContactDetails> cityContact = CityWiseContacts[cityName];
                    Console.WriteLine("\n Contacts in the " + cityName + " City");
                    foreach (ContactDetails contact in cityContact)
                    {
                        ContactDetails.DisplayContact(contact);
                    }
                    break;
                case 2:
                    //Searching contact by state name
                    Console.WriteLine("Enter the state name : ");
                    string stateName = Console.ReadLine();
                    List<ContactDetails> stateContact = StateWiseContacts[stateName];
                    Console.WriteLine("\n Contacts in the " + stateName + " State");
                    foreach (ContactDetails contact in stateContact)
                    {
                        ContactDetails.DisplayContact(contact);
                    }
                    break;
            }
        }
        //Count of contacts in a city or a state
        public static void CountPersonByCityOrState()
        {
            Console.WriteLine(" 1.Count Number of Contacts in City \n 2.Count Number of Contacts in State");
            Console.Write("\n Select Options : ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Enter the city name : ");
                    string cityName = Console.ReadLine();
                    List<ContactDetails> cityContact = CityWiseContacts[cityName];
                    Console.WriteLine("\n Number of Contacts in the " + cityName + " City : " + cityContact.Count);
                    break;
                case 2:
                    Console.Write(" Enter the state name : ");
                    string stateName = Console.ReadLine();
                    List<ContactDetails> stateContact = StateWiseContacts[stateName];
                    Console.WriteLine("\n Number of Contacts in the " + stateName + " State : " + stateContact.Count);
                    break;
            }
        }
    }
}









