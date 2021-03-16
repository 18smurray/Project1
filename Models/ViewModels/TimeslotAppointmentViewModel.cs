using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models.ViewModels
{
    public class TimeslotAppointmentViewModel
    {
        public IEnumerable<Timeslot> Timeslots { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
