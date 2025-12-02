using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripsLogApp.Controllers;
using TripsLogApp.Models;

namespace TripsLogApp.Areas.Controllers
{
    // route tag threw everything off 
    
    [Area("Trip")]
    public class TripController: Controller
    {
        // logging keeps a record of what happens, boilerplate, audting and debugging records use this. 
        private readonly ILogger<TripController> _logger;


        /* this is a constructor that creates the object 
        
        it is the first method that creates any object that is created. 
        setting up ILogger as a parameter for the constructor signals dependency injection to provide the ilogger object or service. 
        dependency injection -> storage and dependency
        
        dependency injection have services that are needed for your project to be readibly available.   
        add this particular service as a dependency. 
        asp.net has built in services and you can create custom services. 
        i have this service that the program will need to implement so I use service.Add to install it in the controller 
        I require these services to be available when I run my code. 
        
        service.Add
        
        injection comes when you request the service. 
        */

        public TripController(ILogger<TripController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Page1()
        {

            return View(new Trip());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Page2(Trip trip)
        {

            if (!ModelState.IsValid)
            {
                return View(nameof(Page1), trip);
            }

            TempData["Trip"] = trip;

            return View(trip);
        }

        [HttpGet]
        public IActionResult Page3(Trip trip)
        {
            if (trip == null)
            {
                return RedirectToAction(nameof(Page1), trip);
            }

            TempData["Trip"] = trip;

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Trip trip)
        {
            if (trip == null)
            {
                return RedirectToAction(nameof(Page1), trip);
            }

            TripRespository.AddTrip(trip);

            return Redirect("~/");
        }
    }
}