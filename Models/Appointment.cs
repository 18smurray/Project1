using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Project1.Models
{
    //so this will be the appointment class. ID is the key, the rest are self-explanitory. 
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentID { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int GroupSize { get; set; }
        //[RegularExpression ] not sure if we need this but could be fun. Could also add to phone. 
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
