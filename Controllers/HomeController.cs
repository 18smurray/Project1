using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
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
        //Private IAppointmentRepository = _repository
            //Will be used to refer to different DBContexts...
            //_reposiotory.Timeslots and _repository.Appointments?

        //Add in parameter IAppointmentRepository repository
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_repository = repository
        }


        //Action for the Home Page
        public IActionResult Index()
        {
            return View();
        }

        //SignUpPage - have to pass in available timeslots
        //Do we need a get and a set to pass the time to the form???
        //Have ID as a hidden field...?

        /*[HttpGet]
         * public IActionResult SignUpPage()
         * {
         *      //Only return timeslots that are not booked yet
         *      return View(_repository.Timeslots
         *          .OrderBy(t => t.Id ??? could use id)
         *          .Where(t => t.Booked == false)
         *          );
         * }
        */
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
         /*[HttpGet]
         * public IActionResult SignUpPage()
         * {
         * 
         *      I could format and return a list of strings here???
         *      Have to grab time and date using the set timeslotid for the appointment
         *      return View(
         *      
         *      )
         *      
         * }
        */













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
