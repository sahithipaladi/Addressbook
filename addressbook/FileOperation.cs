using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AddressBook
{
    class FileOperation
    {
        public static void ReadFromFile(string bookName)
        {
            string filePath = $"D://tvstraining//AddressBook//AddressBook//FileIO//{bookName}.txt";
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
        public static void WriteInToFile(string bookName, ContactBook contactBook)
        {
            try
            {
                string filePath = $"D://tvstraining//AddressBook//AddressBook//BinaryFile//{bookName}.txt";
                StreamWriter sw = new StreamWriter(filePath);
                foreach (ContactDetails list in contactBook.contactList)
                {
                    sw.WriteLine("Name:" + list.firstName + " " + list.lastName + " Address:" + list.address + " City:" + list.city + " State:" + list.state + " Zipcode:" + list.zipcode + " Ph.No:" + list.phonenumber + " Email:" + list.email);
                }
                sw.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}