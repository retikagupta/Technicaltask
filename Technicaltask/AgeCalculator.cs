using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Technicaltask
{
    public class AgeCalculator : IAgeCalculator
    {
        private readonly List<IAddressBook> _records;

        private readonly ICsvHelper _csvhelper;



        public AgeCalculator(ICsvHelper csvHelper)
        {
            _csvhelper = csvHelper;
            _records = _csvhelper.ReadAddressBook();


        }

        public int GetNoOfMales()
        {

            return _records.Where(x => x.Sex.Equals("Male")).Count();

        }

        public string GetOldestPerson()

        {
            _records.OrderBy(x => x.DateOfBirth);
            return _records.FirstOrDefault().Name;
        }

        public double CompareAge(string person1, string person2)
        {
            
            var personA = _records.Where(x => x.Name == person1).FirstOrDefault();
            var personB = _records.Where(x => x.Name == person2).FirstOrDefault();

            var daysDiffrence = (personB.DateOfBirth - personA.DateOfBirth).TotalDays;
            return daysDiffrence;

        }


    }
}
