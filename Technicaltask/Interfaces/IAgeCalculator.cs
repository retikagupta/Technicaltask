using System.Collections.Generic;

namespace Technicaltask
{
    public interface IAgeCalculator
    {
      
        double CompareAge(string person1, string person2);
        int GetNoOfMales();
        string GetOldestPerson();
    }
}