using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using Project1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Variable for the DB context
        private DatabaseContext context { get; set; }

        //Constructor for the Home Controller - initialize the DB context passed as parameter
        public HomeController(ILogger<HomeController> logger, DatabaseContext con)
        {
            _logger = logger;
            context = con;
        }


        //Action for the Home Page - just returns the View
        public IActionResult Index()
        {
            return View();
        }


        //Get Method for the ViewTimeSlots page (when page is first accessed)
        [HttpGet]
        public IActionResult ViewTimeSlots()
        {
            //Returns all the Timeslots in the model where the appointmentid is null
            //Only return timeslots that don't have an appointment already associated with them
            return View(context.Timeslots
                .OrderBy(t => t.TimeslotID)
                .Where(t => t.AppointmentID == null));
        }


        //Overloaded Method 
        //Post method for ViewTimeSlots page (when time slot has been selected)
        //(Kind of servers as a Get method for the ScheduleAppointment page too...)
        [HttpPost]
        public IActionResult ViewTimeSlots(int timeslotid)
        {
            //Get the Timeslot model instance where the timeslotid is equal to the id passed in as a parameter
            Timeslot timeslot = context.Timeslots.Where(t => t.TimeslotID == timeslotid).FirstOrDefault();
            //Set the Timeslot object that corresponds to the id passed in the ViewBag
            //Can use this to reference the timeslot information in the return View
            ViewBag.Timeslot = timeslot;

            //Indicate which view should be returned
            return View("ScheduleAppointment");
        }

        //Post method for the Schedule Appointment page
        //Pass the appointment model structure and timeslotID from the form's hidden input
        [HttpPost]
        public IActionResult ScheduleAppointment(Appointment appt, int timeslotID)
        {
            //Ensures validation constraints for the model are satisfied
            if (ModelState.IsValid)
            {
                //Create a new Appointment model object to be added to the database
                context.Appointments.Add
                    (
                        //Assign the new Appointment attributes the values from the form
                        new Appointment
                        {
                            GroupName = appt.GroupName,
                            GroupSize = appt.GroupSize,
                            Email = appt.Email,
                            Phone = appt.Phone
                        }
                    );

                //Save the changes to the database
                context.SaveChanges();

                //Variable for referencing the appointment most recently added to the database (has the highest appointmentid)
                var lastappt = context.Appointments.Max(x => x.AppointmentID);

                //Variable for referencing the timeslot that corresponds to the timeslotid passed as a parameter
                var AssignedTime = context.Timeslots.Where(t => t.TimeslotID == timeslotID).FirstOrDefault();

                //Sets the appointmentid for the Timeslot as the appointment just created
                AssignedTime.AppointmentID = lastappt;
                //Make sure to save the changes!
                context.SaveChanges();

                //Return to the Home Page
                return View("Index");
            }

            else
            {
                //Reset the ViewBag variable and return the current page (this time validation violations will be shown)
                ViewBag.Timeslot = context.Timeslots.Where(t => t.TimeslotID == timeslotID).FirstOrDefault();
                return View("ScheduleAppointment");
            }
            
        }


        //View Appointments page - display all appointments in the database
        public IActionResult ViewAppointments()
        {
            //Create a list of string to store concatonated appointment and timeslot information 
            List<string> AppList = new List<string>();

            foreach (var x in context.Timeslots)
            {
                //For every timeslot, if the appointmentid is not null (there is an associated appointment)
                if (x.AppointmentID != null)
                {
                    //Variable for referencing the appointment that corresponds to the timeslot (compare the appointment ids)
                    var y = context.Appointments.Where(a => a.AppointmentID == x.AppointmentID).FirstOrDefault();
                    //Concatonate the appointment and timeslot information 
                    //Add the string to the list
                    AppList.Add(string.Format((x.Date).ToString() + " " + y.GroupName + " " + y.GroupSize + " " + y.Phone + " " + y.Email));
                }
            }

            //return the default view and pass it the AppList
            return View(AppList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
