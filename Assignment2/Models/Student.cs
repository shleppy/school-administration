using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    enum Program { SOFTWARE_ENGINEERING, BUSINESS_INFORMATICS }

    class Student : User
    {
        public Program Program { get; set; }

        public Student(string firstname, string lastname, string email, Nationality nationality, Program program, string cohort) 
            : base(firstname, lastname, email, nationality)
        {
            Program = program;
        }
    }
}
