using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripsLogApp.Controllers;
using TripsLogApp.Models;
using TripsLogApp.Repositories; 

namespace TripsLogApp.Areas.Controllers
{
    // route tag threw everything off 
    
    [Area("Trip")]
    public class TripController: Controller
    {
        // logging keeps a record of what happens, boilerplate, audting and debugging records use this. 
        private readonly ILogger<TripController> _logger;

        private readonly TripRespository _respository;

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

        public TripController(ILogger<TripController> logger, TripRespository respository)
        {
            _logger = logger;
            _respository = respository;
        }

        [HttpGet]
        public IActionResult Page1()
        {
            // this will create a new trip object for the web page to use. 
            return View(new Trip());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Page2(Trip trip)
        {
            // if the user fails to input the correct data than show this page again and make them do it again. 
            if (!ModelState.IsValid)
            {
                return View(nameof(Page1), trip);
            }
            // TempData gets updated with the form information and than the view is returned with the trip data.  
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
        public async Task<IActionResult> Add(Trip trip)
        {
        // We will check if the model saved is not null. 
            if (trip == null)
            {
                return RedirectToAction(nameof(Page1), trip);
            }
        
        // when the trip information gets added via succesfful post request, it goes to the repoistory. 
            await _respository.AddTrip(trip);
            
        // controller, return us to the home page! 
            return Redirect("~/");
        }
    }
}