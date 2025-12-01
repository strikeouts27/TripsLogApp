using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripsLogApp.Models;

namespace TripsLogApp.Areas.Controllers
{
    [Area("Trip")]
    [Route("Trip/{Controller}/{action}/{id?}")]
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

        public IActionResult Page1()
        {
            return View();
        }

    }
}