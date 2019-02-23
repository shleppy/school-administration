using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    class Lecturer : User
    {
        public Lecturer(string firstname, string lastname, string email, Nationality nationality) 
            : base(firstname, lastname, email, nationality)
        {

        }
    }
}
