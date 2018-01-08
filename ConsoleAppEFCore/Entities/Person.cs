using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFCore2
{

    public class Person
    {
        public int BusinessEntityID { get; set; }
        public Name Name { get; set; }

    }

    public class Name
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
