using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Timeslot //This is for the individual timeslots. Each will have an id, Date/time and bool to see if it is booked. Also has an appointment. 
    {
        [Key]
        public int TimeslotID { get; set; }
        public DateTime Date { get; set; } //I'm unsure here if Datetime is what I'll want. May be easier to go with string for this?
        public bool Booked { get; set; } = false; //Is this redundant with teh appointment property below?? Could we just 
        public int? AppointmentID { get; set; }
    }
}

