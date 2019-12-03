using System;

namespace Technicaltask
{
    public interface IAddressBook
    {
        DateTime DateOfBirth { get; set; }
        string Name { get; set; }
        string Sex { get; set; }
    }
}