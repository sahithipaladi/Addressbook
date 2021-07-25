using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class CreateContactBooks
    {
        public static int count = 0;
        //Creating dictionary to add contact books
        public static Dictionary<string, ContactBook> contactBookList;
        //Creating contact book list
        public CreateContactBooks()
        {
            contactBookList = new Dictionary<string, ContactBook>();
        }
        //Adding contact book
        public void AddContactBook(string bookName, ContactBook book)
        {

            contactBookList.Add(bookName, book);
            count++;
        }
        //Find by book name
        public bool FindByName(string bookName)
        {
            bool r = contactBookList.ContainsKey(bookName);
            return r;
        }
    }
}




