using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Extension
builder.Services.AddApplicationServices(builder.Configuration);
//Extension
builder.Services.AddIdentityServices(builder.Configuration);

 
var app = builder.Build();

//2-enabling CORS (observer)
app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();