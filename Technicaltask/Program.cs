using Microsoft.Extensions.DependencyInjection;
using System;

namespace Technicaltask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAddressBook, AddressBook>()
                .AddSingleton<ICsvHelper, CsvHelper>()
                .AddSingleton<IAgeCalculator, AgeCalculator>()
                .BuildServiceProvider();

            //string filename = @"C:\Users\regup\Documents\AddressBook.csv";
            var calculateService = serviceProvider.GetService<IAgeCalculator>();

            var noofMales = calculateService.GetNoOfMales();

            Console.WriteLine("No.of Males:" + noofMales);
            var oldestPerson = calculateService.GetOldestPerson();

            Console.WriteLine("Oldest Person is :" + oldestPerson);

            var whoIsOlder = calculateService.CompareAge("John Snow", "Dana Lane");

            Console.WriteLine("John Snow is older than Dana by " + whoIsOlder + " days");

            Console.ReadLine();


        }


    }
}
