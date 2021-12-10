using Microsoft.EntityFrameworkCore;
using webapi.Contexts;
using webapi.Models;
using webapi.Repositories;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ModelBuilder();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepo, MysqlRepo>();

String connectingString = builder.Configuration["ConnectionStrings:DefaultConnection"]; // connection string

builder.Services.AddDbContext<QuizContext>(opt => opt.UseMySql(connectingString, ServerVersion.AutoDetect(connectingString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // maakt het mogelijk om te mappen

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* app.UseHttpsRedirection(); */

app.UseAuthorization();

app.MapControllers();

app.Run();
