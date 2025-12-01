using System.ComponentModel.DataAnnotations;

namespace TripsLogApp.Models;

public class Trip
{
    public int TripId { get; set;}
    [Required]
    public string Destination { get; set;}
    [Required]
    public string Accomodation {get; set;}
    [Required]
    public DateTime StartDate {get; set;} = DateTime.Now;
    [Required]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    public string? AccomodationPhone {get; set;} 
    public string? AccomodationEmail {get; set;}
    public string? Activity1 {get; set;}
    public string? Activity2 {get; set;}
    public string? Activity3 {get; set;}
}