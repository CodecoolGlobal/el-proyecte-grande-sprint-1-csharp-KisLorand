using Badcamp.Services.Interfaces;

using Badcamp;
using Badcamp.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Badcamp.Models;
using Badcamp.Application;
using Badcamp.Infrastucture;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IBadcampContext, BadcampContext>(options =>
{
    var connectionstring = builder.Configuration.GetConnectionString("BadcampContext");
    options.UseSqlServer(connectionstring);
});

builder.Services.AddTransient<BadcampSeed>();


// change to scoped when no longer inmemory
builder.Services.AddSingleton<ISongStorage, SongStorage>();
builder.Services.AddSingleton<UserStorage>();
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<ArtistStorage>();
builder.Services.AddScoped<ArtistPageService>();
builder.Services.AddScoped<ArtistGalleryService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initialiser = services.GetRequiredService<BadcampSeed>();
initialiser.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
