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

        //Add in parameter IAppointmentRepository repository
        public HomeController(ILogger<HomeController> logger, DatabaseContext con)
        {
            _logger = logger;
            context = con;
        }


        //Action for the Home Page
        public IActionResult Index()
        {
            List<string> AppList = new List<string>();

                foreach (var x in context.Timeslots)
                {
                    if (x.AppointmentID != null)
                    {
                        var y = context.Appointments.Where(a => a.AppointmentID == x.AppointmentID).FirstOrDefault();

                        AppList.Add(string.Format((x.Date).ToString() + " " +  y.GroupName + " " + y.GroupSize ));
                    }
                }

                return View(AppList);

        }

            /*return View(new TimeslotAppointmentViewModel
            {
                Timeslots = context.Timeslots,
                Appointments = context.Appointments
            }
                ); */
        

        //SignUpPage - have to pass in available timeslots
        //Do we need a get and a set to pass the time to the form???
        //Have ID as a hidden field...?


        [HttpGet]
        public IActionResult ViewTimeSlots()
        {
            return View(context.Timeslots
                .OrderBy(t => t.TimeslotID)
                .Where(t => t.AppointmentID == null));
        }

        [HttpPost]
        public IActionResult ViewTimeSlots(int timeslotid)
        {
            Timeslot timeslot = context.Timeslots.Where(t => t.TimeslotID == timeslotid).FirstOrDefault();

            ViewBag.Timeslot = timeslot;

            return View("ScheduleAppointment");
        }


        [HttpPost]
        public IActionResult ScheduleAppointment(Appointment appt)
        {


            return View("Index");
        }

        /*[HttpPost] - sending timeslot to the form 
         * public IActionResult SignUpPage(Timeslot.Id timeslotid)
         * {
         *      //Go to the form view and pass the timeslot data 
         *      Could use Viewbag
         *      @ViewBag.TimeId = timeslotid
         *      return View("AppointmentForm" timeslotid)
         * }
        */

        //AppointmentForm page (Can't get to from nav bar - only through the signuppage post method...?


        //Not sure if we need this?
        /*[HttpGet]
         * public IActionResult AppointmentForm(Timeslot.Id timeslotid)
         * {
         *          return View(timeslotid)
         * }
        */

        //For when the appointment form is submitted
        /*[HttpPost]
         * public IActionResult AppointmentForm(Timeslot.id timeslotid Appointment newappt)
         * {
         *          //Ensure model state is valid
         *          if (ModelState.isValid)
         *          
         *          //Have to set timeslot id for the corresponding appointment...
         *          
         *          _repository.Appointments.Add(newappt);
         *          _repository.SaveChanges();
         *  
         *          Need a method for adding new appointments to DB
         *         
         *          //Somehow set booked status for specific DB element
         *          _repository.Timeslot.Where(timeId == timeslotid).Booked == true
         * 
         *          return View(ViewAppointments)
         * }
        */

        
        //View Appointments page
        public IActionResult ViewAppointments()
        {
            List<string> AppList = new List<string>();

            foreach (var x in context.Timeslots)
            {
                if (x.AppointmentID != null)
                {
                    var y = context.Appointments.Where(a => a.AppointmentID == x.AppointmentID).FirstOrDefault();

                    AppList.Add(string.Format((x.Date).ToString() + " " + y.GroupName + " " + y.GroupSize + " " + y.Phone + " " + y.Email));
                }
            }

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
