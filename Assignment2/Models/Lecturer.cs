using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{ 
    public class Lecturer : User
    {
        [UserAttribute("Work Number")]
        public string PhoneNumber { get; set; }
        [UserAttribute("Abbreviaten")]
        public string LecturerAbbreviation { get; set; }
        [UserAttribute("Starting Date")]
        public DateTime StartingDate { get; set; }
    }
}
