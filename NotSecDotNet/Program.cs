using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotSecDotNet.Data;
using NotSecDotNet.model;
using NotSecDotNet.Model;
using NotSecDotNet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlite("Data Source=movie.db"));
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie");
builder.Services.AddRazorPages();
builder.Services.AddScoped<MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();

