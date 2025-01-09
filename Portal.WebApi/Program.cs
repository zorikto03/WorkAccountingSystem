using Portal.WebApi;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

App.ConfigureApplication(app);

app.Run();