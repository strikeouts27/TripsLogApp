var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// making a customized url pattern 
app.MapAreaControllerRoute(
    name: "trip_add",
    areaName: "Trip", 
    // hard coded controller url 
    // usually is pattern is the url that is specified for this section of code to run when the user enteres in a url like this. 
    // we do not provide a default controller in this route. 
    // we can make custom routes with hardcoding 
    pattern: "trip/add/{action=Index}/{id?}",
    // if no controller is specified in the pattern, use this controller specfied in ddefaults as the controller.  the trip controller to be used. 
    defaults: new {controller="Trip"}
    ); 


app.Run();
