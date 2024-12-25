using Persistance.DependencyInjection;
using PortalRazor;
using System.Reflection;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorPages();

Configurations.ConfigureServices( builder.Services, builder.Configuration );

var app = builder.Build();

ConfigureApp( app );

app.Run();

// configure web app 
static void ConfigureApp( WebApplication app )
{
    // Configure the HTTP request pipeline.
    if ( !app.Environment.IsDevelopment() )
    {
        app.UseExceptionHandler( "/Error" );
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
   
    app.MapRazorPages();
}
