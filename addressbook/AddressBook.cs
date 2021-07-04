﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    
    

        class AddressBook
        {

            // List for (Contact) class objects is created.....
            public List<Contact> ContactList;
            public AddressBook()
            {
                this.ContactList = new List<Contact>();
            }
            public void Add_Contacts(Contact contact)
            {
                // add class objects in list c.....
                this.ContactList.Add(contact);
            }
            public int FindByPhoneNumber(int number)
            {
                // Returns the index of Contact....
                return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(number));

            }

        }
    }






