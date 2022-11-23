using CustomMediatr.Api.Models;
using CustomMediatr.Api.Query;
using CustomMediatr.Library;
using CustomMediatr.Library.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomMediator(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.UseCustomMediator();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
