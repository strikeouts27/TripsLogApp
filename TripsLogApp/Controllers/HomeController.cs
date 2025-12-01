using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripsLogApp.Models;

namespace TripsLogApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /* this is a local temporary persistent storage 
    store a list using the trip model and when you do create a _trips=new 
    interfaces are abstract classes that list requirements for classes. 
    we can pass in interfaces into methods can be enforced in method calls or class. 
    classes do not take up memory until an object is made. 
    ICollection is an interface that you can use to assign variables. 
    Try to use the correct data type for each assignment.  
    */
    private List<Trip> _trips=new List<Trip>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // _trips = new List<Trip>()
        // {
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        // };
    }

    public IActionResult Index()
    {
        // strongly typed List 
        // inferred on the razor sytnax 
        // what we pass into this new object <> will specifiy what it can contian.
        // if you try to pass something that is not the specified type it will fail.
        // however, passing in an object type is the universal data type which makes multi data types possible to be accepted. 
        // strongly types objects are better. -> specifiy the type
        // var fakeData = new List<Trip>
        // {
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        //     new Trip{TripId=1, Destination="Dallas", Accomodation="ExitSeat", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(1), AccomodationPhone="404-404-4004", AccomodationEmail ="travler@icloud.com", Activity1="Go To The Rangers Game"},
        // };
        // connected to line 19
        return View(_trips);
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
