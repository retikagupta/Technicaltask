using System.Collections.Generic;

namespace Technicaltask
{
    public interface ICsvHelper
    {
         List<IAddressBook> ReadAddressBook();
    }
}