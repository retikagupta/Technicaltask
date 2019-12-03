using System;
using System.Collections.Generic;
using System.IO;


namespace Technicaltask
{
    public class CsvHelper : ICsvHelper
    {


        private readonly List<IAddressBook> _addresslist;

        private string _filename = @"C:\Users\regup\Documents\AddressBook.csv";

        public CsvHelper()
        {
            _addresslist = new List<IAddressBook>();
        }
        public List<IAddressBook> ReadAddressBook()
        {

            using (var reader = new StreamReader(_filename))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var address = new AddressBook();
                    address.Name = values[0].Trim();
                    address.Sex = values[1].Trim();
                    address.DateOfBirth = Convert.ToDateTime(values[2].Trim());
                    _addresslist.Add(address);

                }
                return _addresslist;
            }

        }



    }
}
