using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultWill
{
    public class Person
    {
        public Person(string surname, string firstName)
        {
            Surname = surname;
            FirstName = firstName;
        }

        public string Surname { get; set; }
        public string FirstName { get; set; }
    }

}
