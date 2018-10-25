using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultWill
{
    public class Doctor : Person
    {
        public Doctor(string surname, string firstName, string email) : base(surname, firstName)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
