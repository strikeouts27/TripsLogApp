using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripsLogApp.Context;
using TripsLogApp.Models;

namespace TripsLogApp.Repositories;

public  class TripRespository
{
    // Generics are objects that take on genric shapes. 
    // Shape object is a generic object, it describes something to take some prebuilt form. 
    // we can extend shapes specification to something more specific like an oval, square. 
    // dictionary key value pairs can hold generic key value pairs, it can take most any type of object. 
    // the angle brackets are used to determine what data types key value pairs or it can be like the frame of a dictionary for what it can take for key value pairs.  
    // once the form is made, i need da containter to hold the data. 
    // what kind of container should i use is the question to ask at this ponint. i need to store the data from the model. simulate a database with an integer key, 
    // keep in mind most projects have a actual database so this is not the normal way of doing things. 

    // this was a mock way of storing data that we commented out close to the end to establish entity framework. 
    // static Dictionary<int,Trip> _trips = new Dictionary<int,Trip>();
    
    // specifiy the starting point of incrementation. its not set up by default. 
    //  int _tripIndex = 1;

    // trips DB has the information we need. 

    private readonly TripsDb _tripsDb;
    public TripRespository(TripsDb tripsDb)
    {
        _tripsDb = tripsDb; 
    } 
     



    public async Task AddTrip(Trip trip)
    {
        // _tripsDb we created and assigned for the table. 
        // Trips is what we called our DbContext 
        // .Add() because we are adding information to the database using EntityFrameworkCore
        // trip is the model information that we pass in. 
        // we are putting it into entity framework. 
        // we inject the user supplied information into the tripsDb database. 
        await _tripsDb.Trips.AddAsync(trip);
        await _tripsDb.SaveChangesAsync();
    }

    // a way to find information. 

    public async Task<Trip?> GetTrip(int id)
    {
        return await _tripsDb.Trips.FindAsync(id);
    }

    public  async Task<Trip?> UpdateTrip(int id, Trip trip)
    // check if the key exists in the dictionary. if it does not return null. 
    // updating something that doesnt exist. 
    {
        var oldTrip = await _tripsDb.Trips.FindAsync(id);
        if (oldTrip == null)
        {
            return null;
        }
        oldTrip = trip; 
        await _tripsDb.SaveChangesAsync();

        return await GetTrip(id);
    }

    public async Task<bool> DeleteTrip(int id)
    {
        // if the search does not contain the key, than the search fails and the delete attempte fails. 
        var oldTrip = await _tripsDb.Trips.FindAsync(id);
        
        if (oldTrip == null)
        {
            return false;
        }
        var entity = _tripsDb.Trips.Remove(oldTrip);

        return entity.State == EntityState.Deleted;
    }

    // dictionary have keys and values. 
    // select method is a link method that allows us to select properties to return back from a collection. 
    // select all the values, the trips inside the dictionary and convert them to a list, and than return it. 
    // Trips were stored in a dictionary container -> that tells you the start point. and than you got to figure out what to convert to make it work for everything else. you may or may not have to convert  here. 
    // when the view or whatever is handling this data, what data type would be best for pulling information for its availability for the view, controller, whatever. 
    // select all from trips 
    // programmers use this to grab all of the data, and than other methods to pull select informaiton. 

    /*
    We had it like this in the beginning but changes were made. 
        public  static List<Trip> GetTrips()
    {
        return _trips.Select(p => p.Value).ToList();
    }
     */
    public async Task<List<Trip>> GetTrips()
    {
        return await _tripsDb.Trips.ToListAsync();
    }
}
