using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{ 
    public class Lecturer : User
    {
        [UserAttribute("work_number")]
        public string PhoneNumber { get; set; }
        [UserAttribute("abbreviation")]
        public string LecturerAbbreviation { get; set; }
        [UserAttribute("starting_date")]
        public DateTime StartingDate { get; set; }
    }
}
