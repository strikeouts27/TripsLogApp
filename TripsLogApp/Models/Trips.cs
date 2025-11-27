namespace TripsLogApp.Models;

public class Trip
{
    public int TripId { get; set;}
    public required string Destination { get; set;} 
    public required string Accomodation {get; set;}
    public required DateTime StartDate {get; set;}
    public required DateTime EndDate {get; set;}
    public string? AccomodationPhone {get; set;} 
    public string? AccomodationEmail {get; set;}
    public string? Activity1 {get; set;}
    public string? Activity2 {get; set;}
    public string? Activity3 {get; set;}
}