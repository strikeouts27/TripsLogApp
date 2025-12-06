using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsLogApp.Models;
using TripsLogApp.Repositories;

namespace TripsLogApp.Context; 

public class TripsDb : DbContext
{
    // we need to tell it what table information the database will have or use. 
    // entity is another word for the model of the database. when EF framework comes in the naming convention is to say it is now an entity. 
    // DbSet <> the angle brackes will hold the model being targeted. Trips is going to be table in the database that we will be targetting with a properties. 
    // properties are fancy wrappers around a field that can do more than just store data. 
    // fields are supposed to be private. 
    // DbSet -> is the same as saying database table. 
    // the this line of code is saying there is a table named Trips go get it and grab all its rows in the model. 
    // as for the columns that will be represented by the properties of the model. 
    public DbSet<Trip> Trips{ get; set; }

    // DbContext needs to know about our TripsDb file. <TripsDb> and options will give it the information it needs. 
    // the contructor that is used for TripsDb needs this informaiton. 
    // a certain file depends on a service to do its job.  
    // a service, wrapper, or microsoft or third party can be set up for dependency injection. 
    // the constructor 
    // service is a module or class that provides a service or need for other classes in my project.  
    // trips is a context file. it is contextually this is the database we will be using 
    // if the parent class allows it we can pass on our parameters to the parent class to do what it needs to do. 
    // we are passing in a reference to the type of file we are currently in on the constructor. 
    // options is the actual variable name that we are passing in. we are injecting in configuration parameters. 
    // base references the base class or parent class. base(options) the abilites we gave the parent class this is because there is a lot of stuff behind the scenes that needs it. 
    public TripsDb(DbContextOptions<TripsDb> options) : base(options)
    {
        
    }

    // db context has on model creating. we can customzie it or overwrite it. 
    // entity is another word for model. 
    // i will call this model entity using the lambda expression. 
    // we pass trip so it can reference the information of the model. 
    // entity gets a hold of the meta data. its funciton is to tell entity framework how to build the database. 
    // after it is built, tell the database how it is built. we will be making calls to this database. this handles data validation that the front end validation may have missed. 
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Trip>(entity =>
        {
           entity.ToTable("Trips"); 
           entity.HasKey(t => t.TripId); 
           entity.Property(b => b.Destination)
                 .IsRequired()
                 .HasMaxLength(255);

            
            entity.Property(b => b.Accomodation)
                 .IsRequired()
                 .HasMaxLength(255);

            entity.Property(b => b.StartDate)
                 .IsRequired()
                 .HasColumnType(nameof(DateTime));
            
            entity.Property(b => b.EndDate)
                 .IsRequired()
                 .HasColumnType(nameof(DateTime));
        });
    }
}