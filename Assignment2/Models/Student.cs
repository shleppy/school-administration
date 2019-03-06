using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{ 
    public class Student : User
    {
        [UserAttribute("study_program")]
        public string StudyProgram { get; set; }
        [UserAttribute("cohort")]
        public string Cohort { get; set; }
        [UserAttribute("class")]
        public string Class { get; set; }
    }
}
