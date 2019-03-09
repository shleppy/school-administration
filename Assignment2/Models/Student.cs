using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{ 
    public class Student : User
    {
        public Student(string first, string last, string nationality, string email, string studyProgram, string cohort, string cl)
            : base(first, last, nationality, email)
        {
            StudyProgram = studyProgram;
            Cohort = cohort;
            Class = cl;
        }

        [UserAttribute("Study Program")]
        public string StudyProgram { get; set; }
        [UserAttribute("Cohort")]
        public string Cohort { get; set; }
        [UserAttribute("Class")]
        public string Class { get; set; }
    }
}
