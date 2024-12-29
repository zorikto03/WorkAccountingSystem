using Application.Configurations;
using Persistance;
using Persistance.DependencyInjection;
using Portal.WebApi;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// initial db
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();