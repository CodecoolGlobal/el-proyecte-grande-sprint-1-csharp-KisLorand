using Badcamp.Services.Interfaces;
using Badcamp;
using Badcamp.Services;
using Badcamp.Models;
using Badcamp.Application;
using Badcamp.Infrastucture;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Badcamp.Application.Common;
using Badcamp.Application.UseCases.SongCases;
using Badcamp.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

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
builder.Services.AddScoped<IRequestHandler<AddSongRequest, Response>, AddSongHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteSongRequest, Response>, DeleteSongHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateSongRequest, Response>, UpdateSongHandler>();
builder.Services.AddScoped<IRequestHandler<GetSongRequest, Response<Song>>, GetSongHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllSongsRequest, Response<IReadOnlyList<Song>>>, GetAllSongsHandler>();
builder.Services.AddSingleton<UserStorage>();
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<ArtistStorage>();
builder.Services.AddScoped<ArtistPageService>();
builder.Services.AddScoped<ArtistGalleryService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initialiser = services.GetRequiredService<BadcampSeed>();
//initialiser.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
   .AllowAnyHeader()
   .AllowAnyMethod()
   .SetIsOriginAllowed((host) => true)
   .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
