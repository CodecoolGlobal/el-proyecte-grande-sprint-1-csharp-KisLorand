
using Badcamp.Services.Interfaces;

using Badcamp;
using Badcamp.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// change to scoped when no longer inmemory
builder.Services.AddSingleton<ISongStorage, SongStorage>();
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<ArtistStorage>();
builder.Services.AddScoped<ArtistPageService>();

var app = builder.Build();

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
