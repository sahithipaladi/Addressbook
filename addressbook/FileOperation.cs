using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

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
                string filePath = $"D://tvstraining//AddressBook//AddressBook//BinaryFile//{bookName}.csv";
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

        //Read Or Write into CSV File
        public static void ReadFromCSVFile(string bookName)
        {
            string filePath = $"D://tvstraining//AddressBook//AddressBook//CSVFile//{bookName}.csv";
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
        public static void WriteIntoCSVFile(string bookName, ContactBook contactBook)
        {
            string path = ($"D://tvstraining//AddressBook//AddressBook//CSVFile//{bookName}.csv");

            using (StreamWriter writer = new StreamWriter(path))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteField(contactBook.contactList);
                }
            }
        }
    }
}