using Microsoft.AspNetCore.Mvc;

namespace TripsLogApp.Areas.Trip.Controllers;

[Area("Trip")]
[Route("Trip/{Controller}/{action}/{id?}")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Page1()
    {
        return View();
    }
}
