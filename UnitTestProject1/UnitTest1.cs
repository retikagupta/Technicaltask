using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
//using NUnit.Framework;
using System.Collections.Generic;
using Technicaltask;


namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTest
    {
        private Mock<ICsvHelper> _mockcsvHelper;
        private IAgeCalculator _calculator;
        private List<IAddressBook> _mylist;

        public CalculatorTest()
        {

            _mockcsvHelper = new Mock<ICsvHelper>();
            _mylist = new List<IAddressBook>();
            _mylist.Add(new AddressBook { Name = "Retika", Sex = "Female", DateOfBirth = new System.DateTime(1987, 07, 26) });
            _mylist.Add(new AddressBook { Name = "Falcon", Sex = "Male", DateOfBirth = new System.DateTime(1987, 07, 25) });
            _mockcsvHelper.Setup(x => x.ReadAddressBook()).Returns(_mylist);
            _calculator = new AgeCalculator(_mockcsvHelper.Object);
            
           

        }

        [TestMethod]
        public void CheckNoOfMales()
        {
                       
            var result = _calculator.GetNoOfMales();
            Assert.IsTrue(result == 1, "1 Male");
        }
        [TestMethod]
        public void CheckOldestPerson()
        {

            var result = _calculator.GetOldestPerson();
            Assert.IsTrue(result == "Retika", "Retika oldest");
        }
        [TestMethod]
        public void CheckWhoIsOlder()
        {

            var result = _calculator.CompareAge("Retika", "Falcon");
            Assert.IsTrue(result == -1, "Falcon is 1 day older than Retika");
        }
        [TestMethod]
        public void CheckWhoIsOlder2()
        {

            var result = _calculator.CompareAge("Falcon", "Retika");
            Assert.IsTrue(result == 1, "Retika 1 day older than Falcon");
        }
    }
}
